using Asa.ApartmentSystemManagement.Core.BaseInfo.DTOs;
using Asa.ApartmentSystemManagement.Core.BaseInfo.Gateways;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Asa.ApartmentSystemManagement.Infra.DataGateways
{
    public class UnitTableGateway : IUnitTableGateway
    {
        string _connectionString;

        public UnitTableGateway(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<UnitDTO>> GetUnitsByBuildingIdAsync(int id)
        {
            var result = new List<UnitDTO>();
            using(var connection = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand())
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "[dbo].[SpUnitsGetAll]";
                    cmd.Parameters.AddWithValue("@buildingId", id);
                    cmd.Connection = connection;
                    cmd.Connection.Open();
                    using (var dataReader = await cmd.ExecuteReaderAsync())
                    {
                        while (await dataReader.ReadAsync())
                        {
                            var unitDTO = new UnitDTO();
                            unitDTO.BuildingId = Convert.ToInt32(dataReader["BuildingId"]);
                            unitDTO.Id = Convert.ToInt32(dataReader["UnitId"]);
                            unitDTO.Area = Convert.ToDecimal(dataReader["Area"]);
                            unitDTO.UnitNumber = Convert.ToInt32(dataReader["UnitNumber"]);
                            unitDTO.Description = Convert.ToString(dataReader["Description"]);
                            result.Add(unitDTO);
                        }
                    }
                }
            }
            return result;
        }

        public async Task<UnitDTO> GetUnitByIdAsync(int id)
        {
            SqlDataReader reader;
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand())
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "[dbo].[SpUnitGet]";
                    cmd.Parameters.AddWithValue("@UnitId", id);
                    cmd.Connection = connection;
                    cmd.Connection.Open();
                    reader = await cmd.ExecuteReaderAsync();
                }
            }

            await reader.ReadAsync();
            var result = new UnitDTO
            {
                BuildingId = id,
                Area = Convert.ToDecimal("Area"),
                UnitNumber = Convert.ToInt32("UnitNumber"),
                Description = Convert.ToString("Description"),
            };

            return result;
        }

        public async Task<int> InsertUnitAsync(UnitDTO unit)
        {
            int id = 0;
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand())
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "[dbo].[SpUniCreate]";
                    cmd.Parameters.AddWithValue("BuildingId", unit.BuildingId);
                    cmd.Parameters.AddWithValue("@Area", unit.Area);
                    cmd.Parameters.AddWithValue("@UnitNumber", unit.UnitNumber);
                    cmd.Parameters.AddWithValue("@Description", unit.Description);
                    cmd.Connection = connection;
                    cmd.Connection.Open();
                    var result = await cmd.ExecuteScalarAsync();
                    id = Convert.ToInt32(result);
                }
            }
            return id;
        }

        public async Task<IEnumerable<UnitDTO>> GetOwnedUnitsAsync(int personId)
        {
            var result = new List<UnitDTO>();
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand())
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "[dbo].[SpGetOwnedUnits]";
                    cmd.Parameters.AddWithValue("@personId", personId);
                    cmd.Connection = connection;
                    cmd.Connection.Open();
                    using (var dataReader = await cmd.ExecuteReaderAsync())
                    {
                        while (await dataReader.ReadAsync())
                        {
                            var unitDTO = new UnitDTO();
                            unitDTO.BuildingId = Convert.ToInt32(dataReader["BuildingId"]);
                            unitDTO.Id = Convert.ToInt32(dataReader["UnitId"]);
                            unitDTO.Area = Convert.ToDecimal(dataReader["Area"]);
                            unitDTO.UnitNumber = Convert.ToInt32(dataReader["UnitNumber"]);
                            unitDTO.Description = Convert.ToString(dataReader["Description"]);
                            result.Add(unitDTO);
                        }
                    }
                }
            }
            return result;
        }
    }
}

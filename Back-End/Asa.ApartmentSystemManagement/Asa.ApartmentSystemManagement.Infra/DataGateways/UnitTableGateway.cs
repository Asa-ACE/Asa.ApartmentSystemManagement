using Asa.ApartmentSystemManagement.Core.BaseInfo.DTOs;
using Asa.ApartmentSystemManagement.Core.BaseInfo.Gateways;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Asa.ApartmentSystemManagement.Infra.DataGateways
{
    class UnitTableGateway : IUnitTableGateway
    {
        string _connectionString;

        public UnitTableGateway(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<UnitDTO>> GetUnitByBuildingId(int id)
        {
            var result = new List<UnitDTO>();
            using(var connecion = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand())
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "[dbo].[units_get_all]";
                    cmd.Parameters.AddWithValue("@building_id", id);
                    cmd.Connection = connecion;
                    cmd.Connection.Open();
                    using (var dataReader = await cmd.ExecuteReaderAsync())
                    {
                        while (await dataReader.ReadAsync())
                        {
                            var unitDTO = new UnitDTO();
                            unitDTO.BuildingId = Convert.ToInt32(dataReader["building_id"]);
                            unitDTO.Id = Convert.ToInt32(dataReader["unit_id"]);
                            unitDTO.Area = Convert.ToDecimal(dataReader["area"]);
                            unitDTO.UnitNumber = Convert.ToInt32(dataReader["unit_number"]);
                            unitDTO.Description = Convert.ToString(dataReader["description"]);
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
                    cmd.CommandText = "[dbo].[unit_get]";
                    cmd.Parameters.AddWithValue("@building_id", id);
                    cmd.Connection = connection;
                    cmd.Connection.Open();
                    reader = await cmd.ExecuteReaderAsync();
                }
            }

            await reader.ReadAsync();
            var result = new UnitDTO
            {
                BuildingId = id,
                Area = Convert.ToDecimal("area"),
                UnitNumber = Convert.ToInt32("unit_number"),
                Description = Convert.ToString("description"),
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
                    cmd.CommandText = "[dbo].[unit_create]";
                    cmd.Parameters.AddWithValue("building_id", unit.BuildingId);
                    cmd.Parameters.AddWithValue("@area", unit.Area);
                    cmd.Parameters.AddWithValue("@unit_number", unit.UnitNumber);
                    cmd.Parameters.AddWithValue("@description", unit.Description);
                    cmd.Connection = connection;
                    cmd.Connection.Open();
                    var result = await cmd.ExecuteScalarAsync();
                    id = Convert.ToInt32(result);
                }
            }
            return id;
        }
    }
}

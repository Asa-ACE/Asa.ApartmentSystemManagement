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

        public Task<UnitDTO> GetUnitByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> InsertUnitAsync(UnitDTO unit)
        {
            throw new NotImplementedException();
        }
    }
}

using Asa.ApartmentSystemManagement.Core.BaseInfo.DTOs;
using Asa.ApartmentSystemManagement.Core.BaseInfo.Gateways;
using Asa.ApartmentSystemManagement.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Asa.ApartmentSystemManagement.Infra.DataGateways
{
    public class ChargeTableGateway : IChargeTableGateway
    {
        string _connectionString;

        public ChargeTableGateway(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task DeleteChargeAsync(int chargeId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand())
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "[dbo].[SpDeleteCharge]";
                    cmd.Parameters.AddWithValue("@chargeId", chargeId);
                    cmd.Connection = connection;
                    cmd.Connection.Open();
                    var result = await cmd.ExecuteScalarAsync();
                    
                }
            }
        }



        public Task<ChargeDTO> GetChargeAsync(int chargeId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<CalculationDTO>> GetCalculationInfosAsync(int chargeId)
        {
                  var result = new List<CalculationDTO>();
                  using (var connecion = new SqlConnection(_connectionString))
                  {
                      using (var cmd = new SqlCommand())
                      {
                          cmd.CommandType = System.Data.CommandType.StoredProcedure;
                          cmd.CommandText = "[dbo].[SpGetOwnersCalculationInfo]";
                          cmd.Parameters.AddWithValue("@chargeId", chargeId);
                          cmd.Connection = connecion;
                          cmd.Connection.Open();
                          using (var dataReader = await cmd.ExecuteReaderAsync())
                          {
                              while (await dataReader.ReadAsync())
                              {
                                  var charges = new CalculationDTO();
                                  charges.
                                  charges.Name = Convert.ToString(dataReader["Name"]);
                                  charges.NumberOfUnits = Convert.ToInt32(dataReader["NumberOfUnits"]);
                                  charges.Address = Convert.ToString(dataReader["Address"]);
                                  result.Add(charges);
                              }
                          }
                      }
                  }
                  return result;
              }

        public async Task<int> InsertChargeAsync(ChargeDTO charge)
        {
            int id = 0;
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand())
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "[dbo].[SpCreateCharge]";
                    cmd.Parameters.AddWithValue("@chargesId", charge.BuildingId);
                    cmd.Parameters.AddWithValue("@from", charge.From);
                    cmd.Parameters.AddWithValue("@to", charge.To);
                    cmd.Connection = connection;
                    cmd.Connection.Open();
                    var result = await cmd.ExecuteScalarAsync();
                    id = Convert.ToInt32(result);
                }
            }
            return id;
        }

        public Task UpdateChargeAsync(ChargeDTO charge)
        {
            throw new NotImplementedException();
        }
    }
}

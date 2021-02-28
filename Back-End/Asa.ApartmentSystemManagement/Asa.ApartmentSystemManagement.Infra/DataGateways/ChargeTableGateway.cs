using Asa.ApartmentSystemManagement.Core.BaseInfo.DTOs;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Asa.ApartmentSystemManagement.Infra.DataGateways
{
    public class ChargeTableGateway
    {
        string _connectionString;

        public ChargeTableGateway(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<ChargeDTO>> GetChargesAsync(int buildingId)
        {
            var result = new List<ChargeDTO>();
            using (var connecion = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand())
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "[dbo].[SpGetCharges]";
                    cmd.Parameters.AddWithValue("@buildingId", buildingId);
                    cmd.Connection = connecion;
                    cmd.Connection.Open();
                    using (var dataReader = await cmd.ExecuteReaderAsync())
                    {
                        while (await dataReader.ReadAsync())
                        {
                            var charge = new ChargeDTO();
                            charge.Id = Convert.ToInt32(dataReader["ChargeId"]);
                            charge.From = Convert.ToDateTime(dataReader["From"]);
                            charge.To = Convert.ToDateTime(dataReader["To"]);
                            result.Add(charge);
                        }
                    }
                }
            }
            return result;
        }
    }
}

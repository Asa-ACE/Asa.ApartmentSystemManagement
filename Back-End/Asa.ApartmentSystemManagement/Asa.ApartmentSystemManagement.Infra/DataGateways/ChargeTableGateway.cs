using Asa.ApartmentSystemManagement.Core.BaseInfo.DTOs;
using Asa.ApartmentSystemManagement.Core.BaseInfo.Gateways;
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
                            charge.Id = Convert.ToInt32(dataReader["ChargeID"]);
                            charge.BuildingId = buildingId;
                            charge.From = Convert.ToDateTime(dataReader["From"]);
                            charge.To = Convert.ToDateTime(dataReader["To"]);
                            result.Add(charge);
                        }
                    }
                }
            }
            return result;
        }

        public async Task<IEnumerable<CalculationDTO>> GetOwnersCalculationInfosAsync(int chargeId)
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
                            var calculation = new CalculationDTO();
                            calculation.ExpenseId = Convert.ToInt32(dataReader["ExpenseID"]);
                            calculation.BuildingId = Convert.ToInt32(dataReader["BuildingID"]);
                            calculation.FormulaName = Convert.ToString(dataReader["FormulaType"]);
                            calculation.Amount = Convert.ToDecimal(dataReader["Amount"]);
                            calculation.From = Convert.ToDateTime(dataReader["From"]);
                            calculation.To = Convert.ToDateTime(dataReader["To"]);
                            result.Add(calculation);
                        }
                    }
                }
            }
            return result;
        }

		public Task<IEnumerable<CalculationDTO>> GetTenantsCalculationInfosAsync(int chargeId)
		{
			throw new NotImplementedException();
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
                    cmd.Parameters.AddWithValue("@buildingId", charge.BuildingId);
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

        public async Task UpdateChargeAsync(ChargeDTO charge)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand())
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "[dbo].[SpChargeUpdate]";
                    cmd.Parameters.AddWithValue("@chargeId", charge.Id);
                    cmd.Parameters.AddWithValue("@buildingId", charge.BuildingId);
                    cmd.Parameters.AddWithValue("@from", charge.From);
                    cmd.Parameters.AddWithValue("@to", charge.To);
                    cmd.Connection = connection;
                    cmd.Connection.Open();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }
    }
}

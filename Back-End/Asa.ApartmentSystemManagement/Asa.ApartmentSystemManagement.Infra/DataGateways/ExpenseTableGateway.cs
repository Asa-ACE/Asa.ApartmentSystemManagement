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
    public class ExpenseTableGateway : IExpenseTableGateway
    {
        private string connectionString;

        public ExpenseTableGateway(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public Task<ExpenseDTO> GetExpenseById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ExpenseDTO> GetExpenseByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<CalculationDTO>> GetCalculationInfosByChargeIdAsync(int chargeId)
        {
            var result = new List<CalculationDTO>();

            using (var connection = new SqlConnection(connectionString))
            {
                using (var cmd = new SqlCommand())
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "[dbo].[SpGetExpensesByChargeId]";
                    cmd.Parameters.AddWithValue("@chargeId", chargeId);
  
                    cmd.Connection = connection;
                    cmd.Connection.Open();
                    using (var dataReader = await cmd.ExecuteReaderAsync())
                    {
                        while (await dataReader.ReadAsync())
                        {
                            var calculationInfo = new CalculationDTO();
                            calculationInfo.Amount = Convert.ToDecimal(dataReader["Amount"]);
                            calculationInfo.ExpenseId = Convert.ToInt32(dataReader["ExpenseID"]);
                            calculationInfo.FormulaName = Convert.ToString(dataReader["FormulaType"]);
                            calculationInfo.From = Convert.ToDateTime(dataReader["From"]);
                            calculationInfo.To = Convert.ToDateTime(dataReader["To"]);
                            calculationInfo.IsForOwner = Convert.ToBoolean(dataReader["IsForOwner"]);
                            calculationInfo.BuildingId = Convert.ToInt32(dataReader["BuildingId"]);
                            result.Add(calculationInfo);
                        }
                    }
                }
            }
            return result;
        }



        public Task<int> InsertExpenseAsync(ExpenseDTO expense)
        {
            throw new NotImplementedException();
        }
    }
}

using Asa.ApartmentSystemManagement.Core.BaseInfo.DTOs;
using Asa.ApartmentSystemManagement.Core.BaseInfo.Gateways;
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

        public async Task<IEnumerable<ExpenseDTO>> GetExpensesByChargeIdAsync(int chargeId)
        {
            var result = new List<ExpenseDTO>();

            using (var connection = new SqlConnection(connectionString))
            {
                using (var cmd = new SqlCommand())
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "[dbo].[SpExpenseGetByDate]";
                    cmd.Parameters.AddWithValue("@chargeId", chargeId);
  
                    cmd.Connection = connection;
                    cmd.Connection.Open();
                    using (var dataReader = await cmd.ExecuteReaderAsync())
                    {
                        while (await dataReader.ReadAsync())
                        {
                            var expenseDTO = new ExpenseDTO();
                            expenseDTO.Amount = Convert.ToDecimal(dataReader["Amount"]);
                            expenseDTO.BuildingId = Convert.ToInt32(dataReader["BuildingID"]);
                            expenseDTO.CategoryId = Convert.ToInt32(dataReader["CategoryID"]);
                            expenseDTO.ExpenseId = Convert.ToInt32(dataReader["ExpenseID"]);
                            expenseDTO.From = Convert.ToDateTime(dataReader["From"]);
                            expenseDTO.To = Convert.ToDateTime(dataReader["To"]);
                            expenseDTO.Name = Convert.ToString(dataReader["Name"]);
                            result.Add(expenseDTO);
                        }
                    }
                }
            }
            return result;
        }



        public async Task<int> InsertExpenseAsync(ExpenseDTO expense)
        {
            int id = 0;
            using (var connection = new SqlConnection(connectionString))
            {
                using (var cmd = new SqlCommand())
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "[dbo].[SpExpenseInsert]";
                    cmd.Parameters.AddWithValue("@buildingId", expense.BuildingId);
                    cmd.Parameters.AddWithValue("@categoryId", expense.CategoryId);
                    cmd.Parameters.AddWithValue("@from", expense.From);
                    cmd.Parameters.AddWithValue("@to", expense.To);
                    cmd.Parameters.AddWithValue("@amount", expense.Amount);
                    cmd.Parameters.AddWithValue("@name", expense.Name);
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

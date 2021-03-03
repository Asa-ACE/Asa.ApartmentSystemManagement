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
        private string _connectionString;

        public ExpenseTableGateway(string connectionString)
        {
                _connectionString = connectionString;
        }


        public async Task<ExpenseDTO> GetExpenseByIdAsync(int id)
        {
            SqlDataReader reader;
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand())
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "[dbo].[SpGetExpense]";
                    cmd.Parameters.AddWithValue("@expenseId", id);
                    cmd.Connection = connection;
                    connection.Open();
                    reader = await cmd.ExecuteReaderAsync();
                }
            }

            await reader.ReadAsync();
            var result = new ExpenseDTO
            {
                ExpenseId = id,
                BuildingId = Convert.ToInt32(reader["BuildingId"]),
                CategoryId = Convert.ToInt32(reader["CategoryId"]),
                From = Convert.ToDateTime(reader["From"]),
                To = Convert.ToDateTime(reader["To"]),
                Amount = Convert.ToDecimal(reader["Amount"]),
                Name = Convert.ToString(reader["Name"])

            };

            return result;
        }

        public async Task<IEnumerable<CalculationDTO>> GetCalculationInfosByChargeIdAsync(int chargeId)
        {
            var result = new List<CalculationDTO>();

            using (var connection = new SqlConnection(_connectionString))
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

        public async Task<int> InsertExpenseAsync(ExpenseDTO expense)
        {
            int id = 0;
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand())
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "[dbo].[SpExpenseCreate]";
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

        public async Task UpdateExpenseAsync(ExpenseDTO expense)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand())
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "[dbo].[SpUpdateExpense]";
                    cmd.Parameters.AddWithValue("@expenseId", expense.ExpenseId);
                    cmd.Parameters.AddWithValue("@buildingId", expense.BuildingId);
                    cmd.Parameters.AddWithValue("@categoryId", expense.CategoryId);
                    cmd.Parameters.AddWithValue("@from", expense.From);
                    cmd.Parameters.AddWithValue("@to", expense.To);
                    cmd.Parameters.AddWithValue("@amount", expense.Amount);
                    cmd.Parameters.AddWithValue("@name", expense.Name);
                    cmd.Connection = connection;
                    cmd.Connection.Open();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task<IEnumerable<ExpenseDTO>> GetExpensesAsync(int buildingId)
        {
            var result = new List<ExpenseDTO>();

            using (var connection = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand())
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "[dbo].[SpGetExpenses]";
                    cmd.Parameters.AddWithValue("@buildingId", buildingId);

                    cmd.Connection = connection;
                    cmd.Connection.Open();
                    using (var dataReader = await cmd.ExecuteReaderAsync())
                    {
                        while (await dataReader.ReadAsync())
                        {
                            var expenseDTO = new ExpenseDTO();
                            expenseDTO.Amount = Convert.ToDecimal(dataReader["Amount"]);
                            expenseDTO.ExpenseId = Convert.ToInt32(dataReader["ExpenseID"]);
                            expenseDTO.From = Convert.ToDateTime(dataReader["From"]);
                            expenseDTO.To = Convert.ToDateTime(dataReader["To"]);
                            expenseDTO.Name = Convert.ToString(dataReader["Name"]);
                            expenseDTO.BuildingId = buildingId;
                            result.Add(expenseDTO);
                        }
                    }
                }
            }
            return result;
        }

        public async Task DeleteExpenseAsync(int expenseId)
        {
            using(var connection = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand())
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "[dbo].[SpDeleteExpense]";
                    cmd.Parameters.AddWithValue("@expenseId", expenseId);
                    cmd.Connection = connection;
                    cmd.Connection.Open();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }
    }
}

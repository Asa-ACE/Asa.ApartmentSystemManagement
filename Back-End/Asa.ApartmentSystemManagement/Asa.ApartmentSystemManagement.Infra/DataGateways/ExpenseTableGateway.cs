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
                    cmd.CommandText = "[dbo].[SpExpenseGet]";
                    cmd.Parameters.AddWithValue("@expenseId", id);
                    cmd.Connection = connection;
                    cmd.Connection.Open();
                    reader = await cmd.ExecuteReaderAsync();
                }
            }

            await reader.ReadAsync();
            var result = new ExpenseDTO
            {
                ExpenseId = id,
                BuildingId = Convert.ToInt32(reader["buildingId"]),
                CategoryId = Convert.ToInt32(reader["categoryId"]),
                From = Convert.ToDateTime(reader["from"]),
                To = Convert.ToDateTime(reader["to"]),
                Amount = Convert.ToDecimal(reader["amount"]),
                Name = Convert.ToString(reader["name"]),
            };

            return result;
        }

        public async Task<IEnumerable<ExpenseDTO>> GetExpensesByBuildingIdAndDateAsync(DateTime from, DateTime to, int buildingId)
        {
            var result = new List<ExpenseDTO>();

            using (var connection = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand())
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "[dbo].[SpExpenseGetByDate]";
                    cmd.Parameters.AddWithValue("@from", from);
                    cmd.Parameters.AddWithValue("@to", to);
                    cmd.Parameters.AddWithValue("@buildingId", buildingId);
                    cmd.Connection = connection;
                    cmd.Connection.Open();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var expenseDTO = new ExpenseDTO();
                            expenseDTO.ExpenseId = Convert.ToInt32(reader["expenseId"]);
                            expenseDTO.BuildingId = Convert.ToInt32(reader["buildingId"]);
                            expenseDTO.CategoryId = Convert.ToInt32(reader["categoryId"]);
                            expenseDTO.From = Convert.ToDateTime(reader["from"]);
                            expenseDTO.To = Convert.ToDateTime(reader["to"]);
                            expenseDTO.Amount = Convert.ToDecimal(reader["amount"]);
                            expenseDTO.Name = Convert.ToString(reader["name"]);
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
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand())
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "[dbo].[SpExpenseCreate]";
                    cmd.Parameters.AddWithValue("@expenseId", expense.ExpenseId);
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

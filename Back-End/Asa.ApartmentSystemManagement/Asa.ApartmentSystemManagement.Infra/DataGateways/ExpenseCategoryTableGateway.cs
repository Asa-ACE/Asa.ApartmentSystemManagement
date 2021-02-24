using Asa.ApartmentSystemManagement.Core.BaseInfo.DTOs;
using Asa.ApartmentSystemManagement.Core.BaseInfo.Gateways;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Asa.ApartmentSystemManagement.Infra.DataGateways
{
    public class ExpenseCategoryTableGateway : IExpenseCategoryTableGateway
    {
        private string _connectionString;

        public ExpenseCategoryTableGateway(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<ExpenseCategoryDTO> GetExpenseCategoryByIdAsync(int id)
        {
            SqlDataReader reader;
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand())
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "[dbo].[SpExpenseCategoryGet]";
                    cmd.Parameters.AddWithValue("@expenseCategoryId", id);
                    cmd.Connection = connection;
                    cmd.Connection.Open();
                    reader = await cmd.ExecuteReaderAsync();
                }
            }

            await reader.ReadAsync();
            var result = new ExpenseCategoryDTO
            {
                CategoryId = id,
                FormulaType = Convert.ToInt32(reader["formulaType"]),
                Name = Convert.ToString(reader["name"]),
                IsForOwner = Convert.ToBoolean(reader["isForOwner"])
            };
            return result;
        }

        public async Task<int> InsertExpenseCategoryAsync(ExpenseCategoryDTO expenseCategory)
        {
            int id = 0;
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand())
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "[dbo].[SpExpenseCategoryCreate]";
                    cmd.Parameters.AddWithValue("@name", expenseCategory.Name);
                    cmd.Parameters.AddWithValue("@formulaType", expenseCategory.FormulaType);
                    cmd.Parameters.AddWithValue("@isForOwner", expenseCategory.IsForOwner);
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

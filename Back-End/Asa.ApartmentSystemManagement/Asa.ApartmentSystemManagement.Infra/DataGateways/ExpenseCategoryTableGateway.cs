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
        string _connectionString;

        public ExpenseCategoryTableGateway(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<ExpenseCategoryDTO>> GetExpenseCategoriesAsync()
        {
            var result = new List<ExpenseCategoryDTO>();
            using (var connection = new SqlConnection(_connectionString))
            {
                using(var cmd = new SqlCommand())
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "[dbo].[SpGetAllExpenseCategories]";
                    cmd.Connection = connection;
                    cmd.Connection.Open();
                    using (var dataReader = await cmd.ExecuteReaderAsync())
                    {
                        while (await dataReader.ReadAsync())
                        {
                            var expenseCategory = new ExpenseCategoryDTO();
                            expenseCategory.CategoryId = Convert.ToInt32(dataReader["CategoryId"]);
                            expenseCategory.FormulaType = Convert.ToString(dataReader["FormulaType"]);
                            expenseCategory.Name = Convert.ToString(dataReader["Name"]);
                            expenseCategory.IsForOwner = Convert.ToBoolean(dataReader["IsForOwner"]);
                            result.Add(expenseCategory);
                        }
                    }

                }
                return result;
            }
        }

        public Task<int> InsertExpenseCategoryAsync(ExpenseCategoryDTO expenseCategory)
        {
            throw new NotImplementedException();
        }
    }
}

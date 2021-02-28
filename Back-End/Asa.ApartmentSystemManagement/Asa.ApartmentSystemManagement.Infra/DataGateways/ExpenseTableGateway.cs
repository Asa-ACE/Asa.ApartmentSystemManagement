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

        public async Task<IEnumerable<ExpenseDTO>> GetExpensesByBuildingIdAndDateAsync(DateTime from, DateTime to, int buildingId)
        {
            var result = new List<ExpenseDTO>();

            using (var connection = new SqlConnection(connectionString))
            {
                using (var cmd = new SqlCommand())
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "[dbo].[SpExpenseGetByDate]";
                    cmd.Parameters.AddWithValue("@buildingId", buildingId);
                    cmd.Parameters.AddWithValue("@from", from);
                    cmd.Parameters.AddWithValue("@to", to);
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



        public Task<int> InsertExpenseAsync(ExpenseDTO expense)
        {
            throw new NotImplementedException();
        }
    }
}

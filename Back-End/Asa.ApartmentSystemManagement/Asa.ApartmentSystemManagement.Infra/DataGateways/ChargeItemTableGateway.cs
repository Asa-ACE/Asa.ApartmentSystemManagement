using Asa.ApartmentSystemManagement.Core.BaseInfo.DTOs;
using Asa.ApartmentSystemManagement.Core.Gateways;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Asa.ApartmentSystemManagement.Infra.DataGateways
{
	public class ChargeItemTableGateway : IChargeItemTableGateway
	{
		string _connectionString;
		public ChargeItemTableGateway(string connectionString)
		{
			_connectionString = connectionString;
		}

		public async Task InsertChargeItemsAsync(IEnumerable<ChargeItemDTO> chargeItems, int chargeId)
		{
			using (var connection = new SqlConnection(_connectionString))
			{
				connection.Open();
				using(var cmd = new SqlCommand())
				{
					cmd.CommandType = System.Data.CommandType.StoredProcedure;
					cmd.CommandText = "[dbo].[SpDeleteChargeItems]";
					cmd.Parameters.AddWithValue("@chargeId", chargeId);
					cmd.Connection = connection;
					await cmd.ExecuteNonQueryAsync();
				}
				foreach (var chargeItem in chargeItems)
				{
					using (var cmd = new SqlCommand())
					{
						cmd.CommandType = System.Data.CommandType.StoredProcedure;
						cmd.CommandText = "[dbo].[SpInsertChargeItem]";
						cmd.Parameters.AddWithValue("@chargeId", chargeId);
						cmd.Parameters.AddWithValue("@unitId", chargeItem.UnitId);
						cmd.Parameters.AddWithValue("@personId", chargeItem.PersonId);
						cmd.Parameters.AddWithValue("@expenseId", chargeItem.ExpenseId);
						cmd.Parameters.AddWithValue("@amount", chargeItem.Amount);
						cmd.Connection = connection;
						await cmd.ExecuteNonQueryAsync();
					}
				}
			}
		}

		public async Task<IEnumerable<UnitChargeDTO>> GetUnitChargesAsync(int unitId, int personId)
		{

		}
	}
}

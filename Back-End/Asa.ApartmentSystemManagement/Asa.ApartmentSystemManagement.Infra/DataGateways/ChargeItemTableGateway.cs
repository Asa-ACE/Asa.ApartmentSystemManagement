using Asa.ApartmentSystemManagement.Core.BaseInfo.DTOs;
using Asa.ApartmentSystemManagement.Core.DTOs;
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

        public async Task<IEnumerable<UnitChargeDTO>> GetOwnedUnitChargesAsync(int unitId, int personId)
        {
			var result = new List<UnitChargeDTO>();
			var chargeItems = new List<UnitChargeItemDTO>();
			using (var connection = new SqlConnection(_connectionString))
			{
				using (var cmd = new SqlCommand())
				{
					cmd.CommandType = System.Data.CommandType.StoredProcedure;
					cmd.CommandText = "[dbo].[SpGetOwnedUnitsChargeItems]";
					cmd.Parameters.AddWithValue("@unitId", unitId);
					cmd.Parameters.AddWithValue("@personId", personId);
					cmd.Connection = connection;
					cmd.Connection.Open();
					using (var dataReader = await cmd.ExecuteReaderAsync())
					{
						while (await dataReader.ReadAsync())
						{
							if(result.Count == 0 || result[result.Count - 1].ChargeId != Convert.ToInt32(dataReader["ChargeID"]))
                            {
								if(result.Count > 0)
                                {
									result[result.Count - 1].ChargeItems = chargeItems;
								}
								chargeItems = new List<UnitChargeItemDTO>();
								var charge = new UnitChargeDTO
								{
									ChargeId = Convert.ToInt32(dataReader["ChargeID"]),
									From = Convert.ToDateTime(dataReader["ChargeFrom"]),
									To = Convert.ToDateTime(dataReader["ChargeTo"])
								};
								result.Add(charge);
                            }
							var chargeItem = new UnitChargeItemDTO();
							chargeItem.ChargeItemId = Convert.ToInt32(dataReader["ChargeItemID"]);
							chargeItem.ExpenseName = Convert.ToString(dataReader["Name"]);
							chargeItem.From = Convert.ToDateTime(dataReader["From"]);
							chargeItem.To = Convert.ToDateTime(dataReader["To"]);
							chargeItem.Amount = Convert.ToDecimal(dataReader["Amount"]);
							chargeItems.Add(chargeItem);
						}
					}
					if(result.Count > 0)
                    {
						result[result.Count - 1].ChargeItems = chargeItems;
					}
				}
			}
			return result;
		}

        public async Task<IEnumerable<UnitChargeDTO>> GetRentedUnitChargesAsync(int unitId, int personId)
        {
			var result = new List<UnitChargeDTO>();
			var chargeItems = new List<UnitChargeItemDTO>();
			using (var connection = new SqlConnection(_connectionString))
			{
				using (var cmd = new SqlCommand())
				{
					cmd.CommandType = System.Data.CommandType.StoredProcedure;
					cmd.CommandText = "[dbo].[SpGetRentedUnitsChargeItems]";
					cmd.Parameters.AddWithValue("@unitId", unitId);
					cmd.Parameters.AddWithValue("@personId", personId);
					cmd.Connection = connection;
					cmd.Connection.Open();
					using (var dataReader = await cmd.ExecuteReaderAsync())
					{
						while (await dataReader.ReadAsync())
						{
							if (result.Count == 0 || result[result.Count - 1].ChargeId != Convert.ToInt32(dataReader["ChargeID"]))
							{
								if (result.Count > 0)
								{
									result[result.Count - 1].ChargeItems = chargeItems;
								}
								chargeItems = new List<UnitChargeItemDTO>();
								var charge = new UnitChargeDTO
								{
									ChargeId = Convert.ToInt32(dataReader["ChargeID"]),
									From = Convert.ToDateTime(dataReader["ChargeFrom"]),
									To = Convert.ToDateTime(dataReader["ChargeTo"])
								};
								result.Add(charge);
							}
							var chargeItem = new UnitChargeItemDTO();
							chargeItem.ChargeItemId = Convert.ToInt32(dataReader["ChargeItemID"]);
							chargeItem.ExpenseName = Convert.ToString(dataReader["Name"]);
							chargeItem.From = Convert.ToDateTime(dataReader["From"]);
							chargeItem.To = Convert.ToDateTime(dataReader["To"]);
							chargeItem.Amount = Convert.ToDecimal(dataReader["Amount"]);
							chargeItems.Add(chargeItem);
						}
					}
					if (result.Count > 0)
					{
						result[result.Count - 1].ChargeItems = chargeItems;
					}
				}
			}
			return result;
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

	}
}

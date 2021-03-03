using Asa.ApartmentSystemManagement.Core.BaseInfo.DTOs;
using Asa.ApartmentSystemManagement.Core.BaseInfo.Gateways;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Asa.ApartmentSystemManagement.Infra.DataGateways
{
    public class TenancyTableGateway : ITenancyTableGateway
    {
        private string _connectionString;

        public TenancyTableGateway(string connectionString)
        {
            _connectionString = connectionString;
        }

		public async Task<IEnumerable<ShareInfo>> GetTenantShareInfoAsync(int buildingId, DateTime from, DateTime to)
        {
            var result = new List<ShareInfo>();

            using (var connection = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand())
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "[dbo].[SpTenancyGetShareInfo]";
                    cmd.Parameters.AddWithValue("@buildingId", buildingId);
                    cmd.Parameters.AddWithValue("@from", from);
                    cmd.Parameters.AddWithValue("@to", to);
                    cmd.Connection = connection;
                    cmd.Connection.Open();
                    using (var dataReader = await cmd.ExecuteReaderAsync())
                    {
                        while (await dataReader.ReadAsync())
                        {
                            var shareInfo = new ShareInfo();
                            shareInfo.BuildingId = Convert.ToInt32(dataReader["BuildingID"]);
                            shareInfo.UnitId = Convert.ToInt32(dataReader["UnitID"]);
                            shareInfo.PersonId = Convert.ToInt32(dataReader["PersonID"]);
                            shareInfo.Days = Convert.ToInt32(dataReader["Days"]);
                            shareInfo.Area = Convert.ToDecimal(dataReader["Area"]);
                            shareInfo.NumberOfPeopel = Convert.ToInt32(dataReader["NumberOfPeopel"]);
                            result.Add(shareInfo);
                        }
                    }
                }
            }
            return result;
        }


        public async Task<int> InsertTenancyAsync(TenancyDTO tenancy)
        {
            int id = 0;
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var cmd = new SqlCommand())
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "[dbo].[SpGetUserIdByUserName]";
                    cmd.Parameters.AddWithValue("@userName", tenancy.PersonName);
                    cmd.Connection = connection;
                    var result = await cmd.ExecuteScalarAsync();
                    if (result == null)
                        throw new ArgumentException("Username Not Exist");
                    tenancy.PersonId = Convert.ToInt32(result);
                }
                using (var cmd = new SqlCommand())
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "[dbo].[SpTenancyCreate]";
                    cmd.Parameters.AddWithValue("@unitId", tenancy.UnitId);
                    cmd.Parameters.AddWithValue("@personId", tenancy.PersonId);
                    cmd.Parameters.AddWithValue("@from", tenancy.From);
                    cmd.Parameters.AddWithValue("@to", tenancy.To);
                    cmd.Parameters.AddWithValue("@numberOfPeople", tenancy.NumberOfPeople);
                    cmd.Connection = connection;
                    var result = await cmd.ExecuteScalarAsync();
                    id = Convert.ToInt32(result);
                }
            }
            return id;
        }

        public async Task UpdateTenancyAsync(DateTime oldFrom, TenancyDTO tenancy)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand())
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "[dbo].[SpUpdateTenancy]";
                    cmd.Parameters.AddWithValue("@oldFrom", oldFrom);
                    cmd.Parameters.AddWithValue("@unitId", tenancy.UnitId);
                    cmd.Parameters.AddWithValue("@personId", tenancy.PersonId);
                    cmd.Parameters.AddWithValue("@from", tenancy.From);
                    cmd.Parameters.AddWithValue("@to", tenancy.To);
                    cmd.Parameters.AddWithValue("@numberOfPeople", tenancy.NumberOfPeople);
                    cmd.Connection = connection;
                    cmd.Connection.Open();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }
    }
}

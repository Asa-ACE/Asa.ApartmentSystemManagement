using Asa.ApartmentSystemManagement.Core.BaseInfo.DTOs;
using Asa.ApartmentSystemManagement.Core.BaseInfo.Gateways;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Asa.ApartmentSystemManagement.Infra.DataGateways
{
    public class OwnershipTableGateway : IOwnershipTableGateway
    {
        string _connectionString;

        public OwnershipTableGateway(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<int> InsertOwnershipAsync(OwnershipDTO ownership)
        {
            int id = 0;
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand())
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "[dbo].[ownership_create]";
                    cmd.Parameters.AddWithValue("@unit_id", ownership.UnitId);
                    cmd.Parameters.AddWithValue("@person_id", ownership.PersonId);
                    cmd.Parameters.AddWithValue("@from", ownership.From);
                    cmd.Parameters.AddWithValue("@to", ownership.To);
                    cmd.Connection = connection;
                    cmd.Connection.Open();
                    var result = await cmd.ExecuteScalarAsync();
                    id = Convert.ToInt32(result);
                }
            }
            return id;
        }

        public async Task UpdateOwnershipAsync(OwnershipDTO ownership)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand())
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "[dbo].[ownership_update]";
                    cmd.Parameters.AddWithValue("@unit_id", ownership.UnitId).Value = ownership.UnitId;
                    cmd.Parameters.AddWithValue("@person_id", ownership.PersonId).Value = ownership.PersonId;
                    cmd.Parameters.AddWithValue("@from", ownership.From).Value = ownership.From;
                    cmd.Parameters.AddWithValue("@to", ownership.To).Value = ownership.To;
                    cmd.Connection = connection;
                    cmd.Connection.Open();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }
    }
}

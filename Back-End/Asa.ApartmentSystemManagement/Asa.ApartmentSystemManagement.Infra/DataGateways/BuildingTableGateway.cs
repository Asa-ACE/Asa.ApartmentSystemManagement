using Asa.ApartmentSystemManagement.Core.BaseInfo.DTOs;
using Asa.ApartmentSystemManagement.Core.BaseInfo.Gateways;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Asa.ApartmentSystemManagement.Infra.DataGateways
{
    public class BuildingTableGateway : IBuildingTableGateway
    {
        string _connectionString;

        public BuildingTableGateway(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<BuildingDTO> GetBuildingByIdAsync(int id)
        {
            SqlDataReader reader;
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand())
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "[dbo].[SpBuildingGet]";
                    cmd.Parameters.AddWithValue("@buildingId", id);
                    cmd.Connection = connection;
                    cmd.Connection.Open();
                    reader = await cmd.ExecuteReaderAsync();
                }
            }

            await reader.ReadAsync();
            var result = new BuildingDTO
            {
                Id = id,
                Name = Convert.ToString(reader["name"]),
                NumberOfUnits = Convert.ToInt32(reader["numberOfUnits"])
            };

            return result;
        }

        public async Task<int> InsertBuildingAsync(BuildingDTO building)
        {
            int id = 0;
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand())
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "[dbo].[SpBuildingCreate]";
                    cmd.Parameters.AddWithValue("@name", building.Name);
                    cmd.Parameters.AddWithValue("@numberOfUnits", building.NumberOfUnits);
                    cmd.Parameters.AddWithValue("address", building.Address);
                    cmd.Connection = connection;
                    cmd.Connection.Open();
                    var result = await cmd.ExecuteScalarAsync();
                    id = Convert.ToInt32(result);
                }
            }
            return id;
        }

        public async Task RemoveBuildingAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand())
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "[dbo].[SpBuildingRemove]";
                    cmd.Connection = connection;
                    cmd.Connection.Open();
                    await cmd.ExecuteNonQueryAsync();
                    cmd.Connection.Close();
                }
            }

        }

        public async Task UpdateBuildingAsync(BuildingDTO building)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand())
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "[dbo].[SpBuildingUpdate]";
                    cmd.Parameters.AddWithValue("@name", building.Name).Value = building.Name;
                    cmd.Parameters.AddWithValue("@address", building.Address).Value = building.Address;
                    cmd.Connection = connection;
                    cmd.Connection.Open();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
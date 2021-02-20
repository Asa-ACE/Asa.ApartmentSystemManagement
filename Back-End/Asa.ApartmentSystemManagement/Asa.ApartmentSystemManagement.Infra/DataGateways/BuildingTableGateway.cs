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
                    cmd.CommandText = "[dbo].[building_get]";
                    cmd.Parameters.AddWithValue("@building_id", id);
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
                NumberOfUnits = Convert.ToInt32(reader["number_of_units"])
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
                    cmd.CommandText = "[dbo].[building_create]";
                    cmd.Parameters.AddWithValue("@name", building.Name);
                    cmd.Parameters.AddWithValue("@number_of_units", building.NumberOfUnits);
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
                    cmd.CommandText = "[dbo].[building_remove]";
                    cmd.Connection = connection;
                    cmd.Connection.Open();
                    //felan gozashtam intor bemune
                    await cmd.ExecuteNonQueryAsync();
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
                    cmd.CommandText = "[dbo].[building_update]";
                    cmd.Parameters.AddWithValue("@name", building.Name).Value = building.Name;
                    cmd.Connection = connection;
                    cmd.Connection.Open();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
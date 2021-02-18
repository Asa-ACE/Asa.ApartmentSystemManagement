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

        public async Task<IEnumerable<BuildingDTO>> GetBuildingById(int id)
        {
            var result = new List<BuildingDTO>();
            DataTable dataTable = new DataTable();
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand())
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "[dbo].[buildings_get_all]";
                    cmd.Parameters.AddWithValue("@BuildingId", id);
                    cmd.Connection = connection;
                    cmd.Connection.Open();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    dataAdapter.Fill(dataTable);
                }
            }

            foreach (DataRow item in dataTable.Rows)
            {
                var dto = new BuildingDTO
                {
                    //Id = Convert.ToInt32(item["BuildingId"]),
                    Name = Convert.ToString(item["Name"]),
                    NumberOfUnits = Convert.ToInt32(item["NumberOfUnits"]),
                    Id = id,
                };
                result.Add(dto);
            }
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
                    cmd.CommandText = "[dbo].[buildings_create]";
                    cmd.Parameters.AddWithValue("@Name", building.Name);
                    cmd.Parameters.AddWithValue("@NumberOfUnits", building.NumberOfUnits);
                    cmd.Connection = connection;
                    cmd.Connection.Open();
                    var result = await cmd.ExecuteScalarAsync();
                    id = Convert.ToInt32(result);
                }
            }
            return id;
        }

        public async Task RemoveBuildingById(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var cmd = new SqlCommand())
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "[dbo].[buildings_remove]";
                    if (cmd.Parameters.Contains(id))
                        cmd.Parameters.Remove(id);
                }

                connection.Close();
            }

        }

        public async Task UpdateBuilding(BuildingDTO building)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand())
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "[dbo].[buildings_update]";
                    cmd.Parameters.AddWithValue("@Name", building.Name).Value = building.Name;
                    cmd.Connection = connection;
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        Task<BuildingDTO> IBuildingTableGateway.GetBuildingById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
﻿using Asa.ApartmentSystemManagement.Core.BaseInfo.DTOs;
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
                    cmd.Parameters.AddWithValue("@BuildingId", id);
                    cmd.Connection = connection;
                    cmd.Connection.Open();
                    reader = await cmd.ExecuteReaderAsync();
                }
            }

            await reader.ReadAsync();
            var result = new BuildingDTO
            {
                Id = id,
                Name = Convert.ToString(reader["Name"]),
                NumberOfUnits = Convert.ToInt32(reader["NumberOfUnits"])
            };

            //foreach (DataRow item in dataTable.Rows)
            //{
            //    var dto = new BuildingDTO
            //    {
            //        //Id = Convert.ToInt32(item["BuildingId"]),
            //        Name = Convert.ToString(item["Name"]),
            //        NumberOfUnits = Convert.ToInt32(item["NumberOfUnits"]),
            //        Id = id,
            //    };
            //    result.Add(dto);
            //}
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
                    cmd.Parameters.AddWithValue("@Name", building.Name).Value = building.Name;
                    cmd.Connection = connection;
                    cmd.Connection.Open();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
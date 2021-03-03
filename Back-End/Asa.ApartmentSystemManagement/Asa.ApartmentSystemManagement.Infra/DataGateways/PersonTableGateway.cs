using Asa.ApartmentSystemManagement.Core.BaseInfo.DTOs;
using Asa.ApartmentSystemManagement.Core.BaseInfo.Gateways;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Asa.ApartmentSystemManagement.Infra.DataGateways
{
    public class PersonTableGateway : IPersonTableGateway
    {
        string _connectionString;

        public PersonTableGateway(string connectionString)
        {
            _connectionString = connectionString;
        }



        public async Task<int> InsertPersonAsync(PersonDTO person)
        {
            int id = 0;
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand())
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "[dbo].[SpPersonCreate]";
                    cmd.Parameters.AddWithValue("@firstName", person.FirstName);
                    cmd.Parameters.AddWithValue("@lastName", person.LastName);
                    cmd.Parameters.AddWithValue("@phoneNumber", person.PhoneNumber);
                    cmd.Parameters.AddWithValue("@userName", person.UserName);
                    cmd.Parameters.AddWithValue("@password", person.Password);
                    cmd.Connection = connection;
                    cmd.Connection.Open();
                    var result = await cmd.ExecuteScalarAsync();
                    id = Convert.ToInt32(result);
                }
            }
            return id;
        }

        public async Task UpdatePersonAsync(PersonDTO person)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand())
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "[dbo].[SpPersonUpdate]";
                    cmd.Parameters.AddWithValue("@firstName", person.FirstName).Value = person.FirstName;
                    cmd.Parameters.AddWithValue("@lastName", person.LastName).Value = person.LastName;
                    cmd.Parameters.AddWithValue("@phoneNumber", person.PhoneNumber).Value = person.PhoneNumber;
                    cmd.Parameters.AddWithValue("@userName", person.UserName).Value = person.UserName;
                    cmd.Parameters.AddWithValue("@password", person.Password).Value = person.Password;
                    cmd.Connection = connection;
                    cmd.Connection.Open();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task<IEnumerable<PersonDTO>> GetTenantsByUnitIdAsync(int unitId)
        {
            var result = new List<PersonDTO>();
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand())
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "[dbo].[SpGetAllTenants]";
                    cmd.Parameters.AddWithValue("@UnitId", unitId);
                    cmd.Connection = connection;
                    cmd.Connection.Open();
                    using (var dataReader = await cmd.ExecuteReaderAsync())
                    {
                        while (await dataReader.ReadAsync())
                        {
                            var person = new PersonDTO();
                            person.Id = Convert.ToInt32(dataReader["PersonId"]);
                            person.FirstName = Convert.ToString(dataReader["FirstName"]);
                            person.LastName = Convert.ToString(dataReader["LastName"]);
                            person.PhoneNumber = Convert.ToString(dataReader["PhoneNumber"]);
                            person.UserName = Convert.ToString(dataReader["UserName"]);
                            result.Add(person);
                        }
                    }
                }
            }
            return result;
        }

        public async Task<IEnumerable<PersonDTO>> GetOwnersByUnitIdAsync(int unitId)
        {
            var result = new List<PersonDTO>();
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand())
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "[dbo].[SpGetAllOwners]";
                    cmd.Parameters.AddWithValue("@UnitId", unitId);
                    cmd.Connection = connection;
                    cmd.Connection.Open();
                    using (var dataReader = await cmd.ExecuteReaderAsync())
                    {
                        while (await dataReader.ReadAsync())
                        {
                            var person = new PersonDTO();
                            person.Id = Convert.ToInt32(dataReader["PersonId"]);
                            person.FirstName = Convert.ToString(dataReader["FirstName"]);
                            person.LastName = Convert.ToString(dataReader["LastName"]);
                            person.PhoneNumber = Convert.ToString(dataReader["PhoneNumber"]);
                            person.UserName = Convert.ToString(dataReader["UserName"]);
                            result.Add(person);
                        }
                    }
                }
            }
            return result;
        }

        public async Task<PersonDTO> AuthenticatePerson(string username, string password)
        {
            SqlDataReader reader;
            PersonDTO person;
            using(var connection = new SqlConnection(_connectionString))
            {
                using(var cmd = new SqlCommand())
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "[dbo].[SpAuthenticate]";
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.Connection = connection;
                    cmd.Connection.Open();
                    reader = await cmd.ExecuteReaderAsync();
                    if (await reader.ReadAsync())
                    {
                        person = new PersonDTO
                        {
                            Id = Convert.ToInt32(reader["PersonID"]),
                            FirstName = Convert.ToString(reader["FirstName"]),
                            LastName = Convert.ToString(reader["LastName"]),
                            UserName = Convert.ToString(reader["UserName"]),
                            Password = Convert.ToString(reader["Password"]),
                            PhoneNumber = Convert.ToString(reader["PhoneNumber"])
                        };
                        return person;
                    }
                }
            }
            return null;
        }
    }
}

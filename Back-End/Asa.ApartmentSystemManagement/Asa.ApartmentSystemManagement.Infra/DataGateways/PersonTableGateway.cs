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

        public async Task<PersonDTO> GetPersonByIdAsync(int id)
        {
            SqlDataReader reader;
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand())
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "[dbo].[person_get]";
                    cmd.Parameters.AddWithValue("@person_id", id);
                    cmd.Connection = connection;
                    connection.Open();
                    reader = await cmd.ExecuteReaderAsync();
                }
            }

            await reader.ReadAsync();
            var result = new PersonDTO
            {
                Id = id,
                FirstName = Convert.ToString("[first_name]"),
                LastName = Convert.ToString("[last_name]"),
                PhoneNumber = Convert.ToString("[phone_number]")
            };

            return result;
        }

        public async Task<int> InsertPersonAsync(PersonDTO person)
        {
            int id = 0;
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand())
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "[dbo].[person_create]";
                    cmd.Parameters.AddWithValue("@fisrt_name", person.FirstName);
                    cmd.Parameters.AddWithValue("@last_name", person.LastName);
                    cmd.Parameters.AddWithValue("@phone_number", person.PhoneNumber);
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
                    cmd.CommandText = "[dbo].[person_update]";
                    cmd.Parameters.AddWithValue("@first_name", person.FirstName).Value = person.FirstName;
                    cmd.Parameters.AddWithValue("@last_name", person.LastName).Value = person.LastName;
                    cmd.Parameters.AddWithValue("@phone_number", person.PhoneNumber).Value = person.PhoneNumber;
                    cmd.Connection = connection;
                    cmd.Connection.Open();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }
    }
}

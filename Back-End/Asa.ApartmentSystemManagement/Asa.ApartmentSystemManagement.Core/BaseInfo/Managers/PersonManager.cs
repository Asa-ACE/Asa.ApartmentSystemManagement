using Asa.ApartmentSystemManagement.Core.BaseInfo.DTOs;
using Asa.ApartmentSystemManagement.Core.BaseInfo.Gateways;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Asa.ApartmentSystemManagement.Core.BaseInfo.Managers
{
	public class PersonManager
	{
		ITableGatewayFactory _tableGatewayFactory;

        public PersonManager(ITableGatewayFactory tableGatewayFactory)
        {
            _tableGatewayFactory = tableGatewayFactory;
        }

        public async Task AddPerson(PersonDTO person)
        {
            ValidatePerson(person);
            var gateway = _tableGatewayFactory.CreatePersonTableGateway();
            var id = await gateway.InsertPersonAsync(person);
            person.Id = id;
        }

        private void ValidatePerson(PersonDTO person)
        {
            if (person.FirstName == "" || person.LastName == "")
            {
                throw new ArgumentNullException("A person must have a valid name.");
            }
            if(!Regex.IsMatch(person.PhoneNumber, @"^\d+$"))
            {
                throw new ArgumentException("Phone number can only contain numbers.");
            }
        }

        public async Task UpdatePersonById(int id, string firstName, string lastName, string phoneNumber)
        {
            var gateway = _tableGatewayFactory.CreatePersonTableGateway();
            var person = await gateway.GetPersonByIdAsync(id);
            person.FirstName = firstName;
            person.LastName = lastName;
            person.PhoneNumber = phoneNumber;
            ValidatePerson(person);
            await gateway.UpdatePersonAsync(person);
        }

    }
}

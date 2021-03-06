﻿using Asa.ApartmentSystemManagement.Core.BaseInfo.DTOs;
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

        public async Task<PersonDTO> AuthenticatePerson(string username, string password)
        {
            var gateway = _tableGatewayFactory.CreatePersonTableGateway();
            var person = await gateway.AuthenticatePerson(username, password);
            return person;
        }

        public async Task AddPersonAsync(PersonDTO person)
        {
            ValidatePerson(person);
            var gateway = _tableGatewayFactory.CreatePersonTableGateway();
            var id = await gateway.InsertPersonAsync(person).ConfigureAwait(false);
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

        public async Task UpdatePersonAsync(PersonDTO personDTO)
        {
            var gateway = _tableGatewayFactory.CreatePersonTableGateway();

            await gateway.UpdatePersonAsync(personDTO).ConfigureAwait(false);
        }
    }
}

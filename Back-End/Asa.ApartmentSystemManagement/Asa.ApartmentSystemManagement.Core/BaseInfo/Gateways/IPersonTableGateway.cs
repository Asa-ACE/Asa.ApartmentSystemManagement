using Asa.ApartmentSystemManagement.Core.BaseInfo.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Asa.ApartmentSystemManagement.Core.BaseInfo.Gateways
{
    public interface IPersonTableGateway
    {
        Task<int> InsertPerson(PersonDTO person);
        Task<PersonDTO> GetPersonById(int id);
    }
}

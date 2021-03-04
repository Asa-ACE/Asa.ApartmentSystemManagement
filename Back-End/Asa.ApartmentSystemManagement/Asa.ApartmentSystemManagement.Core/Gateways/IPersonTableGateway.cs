using Asa.ApartmentSystemManagement.Core.BaseInfo.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Asa.ApartmentSystemManagement.Core.BaseInfo.Gateways
{
    public interface IPersonTableGateway
    {
        Task<int> InsertPersonAsync(PersonDTO person);
        Task UpdatePersonAsync(PersonDTO person);
        Task<IEnumerable<PersonDTO>> GetOwnersByUnitIdAsync(int unitId);
        Task<IEnumerable<PersonDTO>> GetTenantsByUnitIdAsync(int unitId);
        Task<PersonDTO> AuthenticatePerson(string username, string password);
    }
}

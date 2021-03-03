using Asa.ApartmentSystemManagement.ApplicationServices.Model.Mapper;
using Asa.ApartmentSystemManagement.ApplicationServices.Model.Request;
using Asa.ApartmentSystemManagement.ApplicationServices.Model.Response;
using Asa.ApartmentSystemManagement.Core.BaseInfo.Gateways;
using Asa.ApartmentSystemManagement.Core.BaseInfo.Managers;
using Asa.ApartmentSystemManagement.Infra.DataGateways;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Asa.ApartmentSystemManagement.ApplicationServices
{
    public class UserApplicationService
    {
        ITableGatewayFactory _tableGatewayFactory;
        PersonManager _personManager;

        public UserApplicationService(string connectionString)
        {
            _tableGatewayFactory = new SqlTableGatewayFactory(connectionString);
            _personManager = new PersonManager(_tableGatewayFactory);
        }

        public async Task<UserResponse> AuthenticateUser(AuthenticateRequest authInfo)
        {
            var person = await _personManager.AuthenticatePerson(authInfo.Username, authInfo.Password);
            return person.ToUserModel();
        }

        public async Task<int> AddUserAsync(UserRequest user)
        {
            var personDto = user.ToDTO();
            await _personManager.AddPerson(personDto);
            return personDto.Id;
        }
    }
}

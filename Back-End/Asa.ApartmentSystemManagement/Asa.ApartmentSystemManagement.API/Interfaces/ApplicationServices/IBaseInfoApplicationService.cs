using Asa.ApartmentSystemManagement.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asa.ApartmentSystemManagement.API.Interfaces.ApplicationServices
{
    public interface IBaseInfoApplicationService
    {
        IEnumerable<BuildingResponse> GetBuildings(int UserId);
    }
}

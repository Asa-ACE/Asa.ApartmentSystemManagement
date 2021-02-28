using Asa.ApartmentSystemManagement.API.Model;
using Asa.ApartmentSystemManagement.API.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asa.ApartmentSystemManagement.API.Interfaces.ApplicationServices
{
    public interface IChargeApplicationService
    {

        IEnumerable<ChargeAndChargeItemResponse> GetChargesInUnitIOwn(int userId, int unitId);
        IEnumerable<ChargeAndChargeItemResponse> GetChargesInUnitIRent(int userId, int unitId);
    }
}

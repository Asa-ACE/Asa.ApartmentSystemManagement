using Asa.ApartmentSystemManagement.Core.BaseInfo.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Asa.ApartmentSystemManagement.Core.Gateways
{
    public interface IChargeTableGateway
    {
        Task<IEnumerable<ChargeDTO>> GetChargesAsync(int builidingId);

    }
}

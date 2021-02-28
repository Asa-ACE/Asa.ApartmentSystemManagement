using Asa.ApartmentSystemManagement.ApplicationServices.Model.Request;
using Asa.ApartmentSystemManagement.Core.BaseInfo.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asa.ApartmentSystemManagement.ApplicationServices.Model.Mapper
{
    public static class ChargeMapper
    {
        public static ChargeDTO ToDTO(this CreateChargeRequest chargeRequest)
        {
            var dto = new ChargeDTO
            {
                BuildingId = chargeRequest.BuildingId,
                From = chargeRequest.From,
                To = chargeRequest.To
            };
            return dto;
        }
    }
}

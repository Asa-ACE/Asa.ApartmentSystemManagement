using Asa.ApartmentSystemManagement.ApplicationServices.Model.Request;
using Asa.ApartmentSystemManagement.ApplicationServices.Model.Response;
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
        
        public static IEnumerable<ChargeResponseBuilding> ToModel(this IEnumerable<ChargeDTO> charges)
        {
            List<ChargeResponseBuilding> model = new List<ChargeResponseBuilding>();
            foreach (var charge in charges)
            {
                model.Add(charge.ToModel());
            }
            return model;
        }

        public static ChargeResponseBuilding ToModel(this ChargeDTO charge)
        {
            var model = new ChargeResponseBuilding();
            model.ChargeId = charge.Id;
            model.BuildingId = charge.BuildingId;
            model.From = charge.From;
            model.To = charge.To;
            return model;
        }

    }
}

using Asa.ApartmentSystemManagement.ApplicationServices.Model.Response;
using Asa.ApartmentSystemManagement.Core.BaseInfo.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asa.ApartmentSystemManagement.ApplicationServices.Model.Mapper
{
    public static class ChargeMapper
    {
        public static ChargeResponse ToModel(this ChargeDTO charge)
        {
            ChargeResponse model = new ChargeResponse();
            model.From = charge.From;
            model.To = charge.To;
            model.Id = charge.Id;
            return model;
        }

        public static IEnumerable<ChargeResponse> ToModel(this IEnumerable<ChargeDTO> charges)
        {
            List<ChargeResponse> model = new List<ChargeResponse>();
            foreach (var charge in charges)
            {
                model.Add(charge.ToModel());
            }
            return model;
        }
    }
}
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

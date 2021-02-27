using Asa.ApartmentSystemManagement.ApplicationServices.Model.Request;
using Asa.ApartmentSystemManagement.Core.BaseInfo.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asa.ApartmentSystemManagement.ApplicationServices.Model.Mapper
{
    public static class TenantMapper
    {
        public static TenancyDTO ToDTO(this TenantRequest owner)
        {
            TenancyDTO dto = new TenancyDTO
            {
                PersonId = owner.PersonId,
                From = owner.From,
                To = owner.To,
                UnitId = owner.UnitId
            };
            return dto;
        }
    }
}

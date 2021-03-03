using Asa.ApartmentSystemManagement.ApplicationServices.Model.Request;
using Asa.ApartmentSystemManagement.Core.BaseInfo.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asa.ApartmentSystemManagement.ApplicationServices.Model.Mapper
{
    public static class TenantMapper
    {
        public static TenancyDTO ToDTO(this TenantRequest tenant)
        {
            TenancyDTO dto = new TenancyDTO
            {
                PersonId = tenant.PersonId,
                UserName = tenant.PersonName,
                From = tenant.From,
                To = tenant.To,
                UnitId = tenant.UnitId,
                NumberOfPeople = tenant.NumberOfPeople
            };
            return dto;
        }
        public static TenancyDTO ToDTO(this ChangeTenantRequest tenant)
        {
            TenancyDTO dto = new TenancyDTO
            {
                PersonId = tenant.PersonId,
                UserName = tenant.PersonName,
                From = tenant.From,
                To = tenant.To,
                UnitId = tenant.UnitId,
                NumberOfPeople = tenant.NumberOfPeople
            };
            return dto;
        }

    }

}

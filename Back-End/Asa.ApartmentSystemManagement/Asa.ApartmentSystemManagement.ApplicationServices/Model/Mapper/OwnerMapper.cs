using Asa.ApartmentSystemManagement.ApplicationServices.Model.Request;
using Asa.ApartmentSystemManagement.Core.BaseInfo.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asa.ApartmentSystemManagement.ApplicationServices.Model.Mapper
{
    public static class OwnerMapper
    {
        public static OwnershipDTO ToDTO(this OwnerRequest owner)
        {
            OwnershipDTO dto = new OwnershipDTO
            {
                PersonName = owner.PersonName,
                PersonId = owner.PersonId,
                From = owner.From,
                To = owner.To,
                UnitId = owner.UnitId
            };
            return dto;
        }
    }
}

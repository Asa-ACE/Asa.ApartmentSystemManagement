using Asa.ApartmentSystemManagement.ApplicationServices.Model.Response;
using Asa.ApartmentSystemManagement.Core.BaseInfo.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asa.ApartmentSystemManagement.ApplicationServices.Model.Mapper
{
    public static class PersonMapper
    {
        public static OwnerResponse ToModel(this PersonDTO person)
        {
            OwnerResponse model = new OwnerResponse();
            model.Id = person.Id;
            model.FirstName = person.FirstName;
            model.LastName = person.LastName;
            model.PhoneNumber = person.PhoneNumber;
            model.UserName = person.UserName;
            return model;
        }
    }
}

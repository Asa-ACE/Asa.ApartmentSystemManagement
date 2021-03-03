using Asa.ApartmentSystemManagement.ApplicationServices.Model.Request;
using Asa.ApartmentSystemManagement.ApplicationServices.Model.Response;
using Asa.ApartmentSystemManagement.Core.BaseInfo.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asa.ApartmentSystemManagement.ApplicationServices.Model.Mapper
{
    public static class PersonMapper
    {
        public static OwnerResponse ToOwnerModel(this PersonDTO person)
        {
            OwnerResponse model = new OwnerResponse();
            model.Id = person.Id;
            model.FirstName = person.FirstName;
            model.LastName = person.LastName;
            model.PhoneNumber = person.PhoneNumber;
            model.UserName = person.UserName;
            return model;
        }

        public static IEnumerable<OwnerResponse> ToOwnerModel(this IEnumerable<PersonDTO> persons)
        {
            List<OwnerResponse> model = new List<OwnerResponse>();
            foreach (var person in persons)
            {
                model.Add(person.ToOwnerModel());
            }
            return model;
        }

        public static TenantResponse ToTenantModel(this PersonDTO person)
        {
            TenantResponse model = new TenantResponse();
            model.PersonId = person.Id;
            model.FirstName = person.FirstName;
            model.LastName = person.LastName;
            model.PhoneNumber = person.PhoneNumber;
            model.UserName = person.UserName;
            return model;
        }

        public static IEnumerable<TenantResponse> ToTenantModel(this IEnumerable<PersonDTO> persons)
        {
            List<TenantResponse> model = new List<TenantResponse>();
            foreach (var person in persons)
            {
                model.Add(person.ToTenantModel());
            }
            return model;
        }

        public static UserResponse ToUserModel(this PersonDTO person)
        {
            if(person == null)
            {
                return null;
            }
            var model = new UserResponse
            {
                UserId = person.Id,
                UserName = person.UserName,
                FirstName = person.FirstName,
                LastName = person.LastName
            };
            return model;
        }

        public static PersonDTO ToDTO(this UserRequest user)
        {
            var dto = new PersonDTO()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Password = user.Password,
                PhoneNumber = user.PhoneNumber,
                UserName = user.Username
            };
            return dto;
        }
    }
}

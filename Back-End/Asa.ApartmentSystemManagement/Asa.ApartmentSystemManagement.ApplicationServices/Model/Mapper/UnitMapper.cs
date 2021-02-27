using Asa.ApartmentSystemManagement.ApplicationServices.Model.Response;
using Asa.ApartmentSystemManagement.Core.BaseInfo.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asa.ApartmentSystemManagement.ApplicationServices.Model.Mapper
{
    public static class UnitMapper
    {
        public static UnitResponse ToModel(this UnitDTO unit)
        {
            UnitResponse model = new UnitResponse();
            model.Id = unit.Id;
            model.Area = unit.Area;
            model.Description = unit.Description;
            model.UnitNumber = unit.UnitNumber;
            return model;
        }

        public static IEnumerable<UnitResponse> ToModel(this IEnumerable<UnitDTO> units)
        {
            List<UnitResponse> model = new List<UnitResponse>();
            foreach (var unit in units)
            {
                model.Add(unit.ToModel());
            }
            return model;
        }
    }
}

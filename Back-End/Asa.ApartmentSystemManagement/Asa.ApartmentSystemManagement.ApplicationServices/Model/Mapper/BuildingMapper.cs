using Asa.ApartmentSystemManagement.ApplicationServices.Model.Response;
using Asa.ApartmentSystemManagement.Core.BaseInfo.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asa.ApartmentSystemManagement.ApplicationServices.Model.Mapper
{
    public static class BuildingMapper
    {
        public static BuildingResponse ToModel(this BuildingDTO building)
        {
            BuildingResponse model = new BuildingResponse
            {
                Id = building.Id,
                Name = building.Name,
                NumberOfUnits = building.NumberOfUnits,
                Address = building.Address
            };
            return model;
        }

        public static IEnumerable<BuildingResponse> ToModel(this IEnumerable<BuildingDTO> buildings)
        {
            List<BuildingResponse> model = new List<BuildingResponse>();
            foreach (var building in buildings)
            {
                model.Add(building.ToModel());
            }
            return model;
        }
    }
}

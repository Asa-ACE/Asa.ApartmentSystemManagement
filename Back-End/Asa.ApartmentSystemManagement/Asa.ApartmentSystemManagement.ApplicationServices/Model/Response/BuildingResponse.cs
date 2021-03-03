using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asa.ApartmentSystemManagement.ApplicationServices.Model.Response
{
    public class BuildingResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NumberOfUnits { get; set; }
        public string Address { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asa.ApartmentSystemManagement.ApplicationServices.Model.Request
{
    public class BuildingRequest
    {
        public string Name { get; set; }
        public int NumberOfUnits { get; set; }
        public string Address { get; set; }
    }
}

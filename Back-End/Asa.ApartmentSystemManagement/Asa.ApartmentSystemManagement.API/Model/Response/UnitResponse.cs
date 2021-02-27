using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asa.ApartmentSystemManagement.API.Model.Response
{
    public class UnitResponse
    {
        public int Id { get; set; }
        public int BuildingId { get; set; }
        public decimal Area { get; set; }
        public int UnitNumber { get; set; }
        public string Description { get; set; }
    }
}

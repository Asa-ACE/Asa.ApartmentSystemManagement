using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asa.ApartmentSystemManagement.ApplicationServices.Model.Response
{
    public class UnitResponse
    {
        public int Id { get; set; }
        public int BuildingId { get; set; }
        public decimal Area { get; set; }
        public int UnitNumber { get; set; }
    }
}

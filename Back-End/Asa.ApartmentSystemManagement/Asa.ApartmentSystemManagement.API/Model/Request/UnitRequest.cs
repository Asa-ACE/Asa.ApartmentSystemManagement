using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asa.ApartmentSystemManagement.API.Model.Request
{
    public class UnitRequest
    {
        public decimal Area { get; set; }
        public int UnitNumber { get; set; }
        public string Description { get; set; }
    }
}

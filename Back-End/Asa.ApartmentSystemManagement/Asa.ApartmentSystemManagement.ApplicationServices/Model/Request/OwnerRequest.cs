using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asa.ApartmentSystemManagement.ApplicationServices.Model.Request
{
    public class OwnerRequest
    {
        public string PersonName { get; set; }
        public int PersonId { get; set; }
        public DateTime From { get; set; }
        public DateTime? To { get; set; }
        public int UnitId { get; set; }
    }
}

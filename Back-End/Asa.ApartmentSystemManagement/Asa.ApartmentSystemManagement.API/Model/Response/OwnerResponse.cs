using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asa.ApartmentSystemManagement.API.Model.Response
{
    public class OwnerResponse
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int UnitId { get; set; }
        public DateTime From { get; set; }
        public DateTime? To { get; set; }
    }
}

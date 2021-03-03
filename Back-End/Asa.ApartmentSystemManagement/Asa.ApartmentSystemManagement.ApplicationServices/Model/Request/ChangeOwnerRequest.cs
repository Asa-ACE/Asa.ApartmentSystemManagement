using System;
using System.Collections.Generic;
using System.Text;

namespace Asa.ApartmentSystemManagement.ApplicationServices.Model.Request
{
    public class ChangeOwnerRequest
    {
        public string PersonName { get; set; }
        public int PersonId { get; set; }
        public DateTime From { get; set; }
        public DateTime? To { get; set; }
        public int UnitId { get; set; }
        public DateTime OldFrom { get; set; }
    }
}

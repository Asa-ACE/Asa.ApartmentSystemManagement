using System;
using System.Collections.Generic;
using System.Text;

namespace Asa.ApartmentSystemManagement.ApplicationServices.Model.Response
{
    public class ChargeResponseBuilding
    {
        public int ChargeId { get; set; }
        public int BuildingId { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
    }
}

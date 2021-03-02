using System;
using System.Collections.Generic;
using System.Text;

namespace Asa.ApartmentSystemManagement.ApplicationServices.Model.Request
{
    public class ChargeCalculationRequest
    {
        public int ChargeId { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }

    }
}

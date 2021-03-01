using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asa.ApartmentSystemManagement.ApplicationServices.Model.Response
{
    public class UnitChargeResponse
    {
		public int ChargeId { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public IEnumerable<ChargeItemResponse> ChargeItems { get; set; }
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asa.ApartmentSystemManagement.ApplicationServices.Model.Response
{
    public class GetUnitChargeResponse
    {
		public string Name { get; set; }
		public IEnumerable<ChargeItemResponse> ChargeItems { get; set; }
	}
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Asa.ApartmentSystemManagement.ApplicationServices.Model.Request
{
	public class CreateChargeRequest
	{
		public int BuildingId { get; set; }
		public DateTime From { get; set; }
		public DateTime To { get; set; }
	}
}

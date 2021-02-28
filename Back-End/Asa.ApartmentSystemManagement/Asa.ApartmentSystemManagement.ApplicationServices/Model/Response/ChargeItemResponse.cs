using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asa.ApartmentSystemManagement.ApplicationServices.Model.Response
{
    public class ChargeItemResponse
    {
        public int Id { get; set; }
		public string ExpenseName { get; set; }
		public decimal Amount { get; set; }
	}
}

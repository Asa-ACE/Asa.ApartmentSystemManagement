using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asa.ApartmentSystemManagement.ApplicationServices.Model.Request
{
    public class ExpenseRequest
    {
        public int CategoryId { get; set; }
        public int BuildingId { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public decimal Amount { get; set; }
        public string Name { get; set; }
    }
}

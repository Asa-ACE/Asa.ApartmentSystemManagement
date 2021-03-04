using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asa.ApartmentSystemManagement.ApplicationServices.Model.Response
{
    public class ExpenseResponse
    {
        public int ExpenseId { get; set; }
        public int CategoryId { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public decimal Amount { get; set; }
        public string Name { get; set; }
    }
}

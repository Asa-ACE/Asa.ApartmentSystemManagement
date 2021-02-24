using System;
using System.Collections.Generic;
using System.Text;

namespace Asa.ApartmentSystemManagement.Core.BaseInfo.DTOs
{
    public class ExpenseDTO
    {
        public int ExpenseId { get; set; }
        public int BuildingId { get; set; }
        public int CategoryId { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public decimal Amount { get; set; }
        public string Name { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Asa.ApartmentSystemManagement.Core.BaseInfo.DTOs
{
    public class ChargeItemDTO
    {
        public int Id { get; set; }
        public int ExpenseId { get; set; }
        public int ChargeId { get; set; }
        public decimal Amount { get; set; }
    }
}

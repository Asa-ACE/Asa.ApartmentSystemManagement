using System;
using System.Collections.Generic;
using System.Text;

namespace Asa.ApartmentSystemManagement.Core.DTOs
{
    public class UnitChargeItemDTO
    {
        public int ChargeItemId { get; set; }
        public string ExpenseName { get; set; }
        public decimal Amount { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
    }
}

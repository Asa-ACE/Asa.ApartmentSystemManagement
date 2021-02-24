using System;
using System.Collections.Generic;
using System.Text;

namespace Asa.ApartmentSystemManagement.Core.BaseInfo.DTOs
{
    public class PaymentDTO
    {
        public int Days { get; set; }
        public decimal Area { get; set; }
        public int PersonId { get; set; }
        public int UnitId { get; set; }
        public int NumberOfPeopel { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asa.ApartmentSystemManagement.API.Model.Response
{
    public class ChargeItemResponse
    {
        public int Id { get; set; }
        public int ExpenseId { get; set; }
        public int PersonId { get; set; }
        public int UnitId { get; set; }
        public decimal Amount { get; set; }
        public bool IsOwner { get; set; }
    }
}

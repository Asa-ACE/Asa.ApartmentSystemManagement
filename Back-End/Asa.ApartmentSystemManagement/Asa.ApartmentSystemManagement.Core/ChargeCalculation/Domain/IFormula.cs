using Asa.ApartmentSystemManagement.Core.BaseInfo.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace ASa.ApartmentManagement.Core.ChargeCalculation.Domain
{
    public interface IFormula
    {
        List<ChargeItemDTO> Calculate(decimal amount,IEnumerable<PaymentDTO> payments, int expenseId);
    }
}

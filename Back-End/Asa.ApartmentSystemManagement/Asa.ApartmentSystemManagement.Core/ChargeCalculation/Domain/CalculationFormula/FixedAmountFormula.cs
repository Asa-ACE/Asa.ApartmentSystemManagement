using Asa.ApartmentSystemManagement.Core.BaseInfo.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace ASa.ApartmentManagement.Core.ChargeCalculation.Domain.CalculationFormula
{
    [CalculationFormula("مقدار ثابت")]
    public class FixedAmountFormula : IFormula
    {
        public List<ChargeItemDTO> Calculate(decimal amount, IEnumerable<PaymentDTO> payments, int numberOfUnits)
        {
            throw new NotImplementedException();
        }
    }
}

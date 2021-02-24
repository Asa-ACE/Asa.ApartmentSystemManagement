using Asa.ApartmentSystemManagement.Core.BaseInfo.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace ASa.ApartmentManagement.Core.ChargeCalculation.Domain.CalculationFormula
{
    [CalculationFormula("بر حسب مساحت واحد")]
    public class AreaBasedFormula : IFormula
    {
        public List<ChargeItemDTO> Calculate(decimal amount, IEnumerable<PaymentDTO> payments , int expenseId)
        {
            decimal sum = 0;
            List<ChargeItemDTO> chargeItems=null;

            foreach (var payment in payments)
            {
                sum += payment.Area * payment.Days;
            }
            foreach (var payment in payments)
            {

            }

            return chargeItems;
        }
    }
}
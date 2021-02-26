using Asa.ApartmentSystemManagement.Core.BaseInfo.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace ASa.ApartmentManagement.Core.ChargeCalculation.Domain.CalculationFormula
{
    [CalculationFormula("بر حسب تعداد نفرات")]
    public class PeopelBasedFormula : IFormula
    {
        public List<ChargeItemDTO> Calculate(decimal amount, IEnumerable<ShareInfo> payments , int expenseId , bool IsOwner)
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
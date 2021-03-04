using Asa.ApartmentSystemManagement.Core.BaseInfo.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asa.ApartmentSystemManagement.Core.ChargeCalculation.Domain.CalculationFormula
{
    [CalculationFormula("به صورت مساوی")]
    public class EqualAmountFormula : IFormula
    {
        public List<ChargeItemDTO> Calculate(decimal amount, IEnumerable<ShareInfo> shareInfos, int expenseId, bool isOwner)
        {
            decimal sum = 0;
            List<ChargeItemDTO> chargeItems = new List<ChargeItemDTO>();

            foreach (var shareInfo in shareInfos)
            {
                sum += shareInfo.Days;
            }
            foreach (var shareInfo in shareInfos)
            {
                var chargeItem = new ChargeItemDTO();
                chargeItem.Amount = amount * ((shareInfo.Days) / sum);
                chargeItem.ExpenseId = expenseId;
                chargeItem.PersonId = shareInfo.PersonId;
                chargeItem.UnitId = shareInfo.UnitId;
                chargeItem.IsOwner = isOwner;
                chargeItems.Add(chargeItem);
            }

            return chargeItems;
        }
    }
}

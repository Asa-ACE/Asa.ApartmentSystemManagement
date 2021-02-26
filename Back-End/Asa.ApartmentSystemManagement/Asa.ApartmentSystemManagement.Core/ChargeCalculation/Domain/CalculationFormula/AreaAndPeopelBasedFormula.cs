using Asa.ApartmentSystemManagement.Core.BaseInfo.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace ASa.ApartmentManagement.Core.ChargeCalculation.Domain.CalculationFormula
{
    [CalculationFormula("بر اساس مساحت و تعداد نفرات")]
    public class AreaAndPeopelBasedFormula : IFormula
    {
        public List<ChargeItemDTO> Calculate(decimal amount, IEnumerable<ShareInfo> shareInfos, int expenseId, bool isOwner)
        {
            decimal sum = 0;
            List<ChargeItemDTO> chargeItems = null;

            foreach (var shareInfo in shareInfos)
            {
                sum += shareInfo.Days * shareInfo.NumberOfPeopel * shareInfo.Area;
            }
            foreach (var shareInfo in shareInfos)
            {
                var chargeItem = new ChargeItemDTO();
                chargeItem.Amount = amount * ((shareInfo.Days * shareInfo.NumberOfPeopel * shareInfo.Area) / sum);
                chargeItem.ExpenseId = expenseId;
                chargeItem.PersonId = shareInfo.PersonId;
                chargeItem.UnitId = shareInfo.UnitId;
                chargeItem.IsOwner = isOwner;
            }

            return chargeItems;
        }
    }
}

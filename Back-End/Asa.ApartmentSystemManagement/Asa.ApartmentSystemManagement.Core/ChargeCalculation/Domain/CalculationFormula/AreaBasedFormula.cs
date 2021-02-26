using Asa.ApartmentSystemManagement.Core.BaseInfo.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace ASa.ApartmentManagement.Core.ChargeCalculation.Domain.CalculationFormula
{
    [CalculationFormula("بر حسب مساحت واحد")]
    public class AreaBasedFormula : IFormula
    {
        public List<ChargeItemDTO> Calculate(decimal amount, IEnumerable<ShareInfo> shareInfos , int expenseId, bool isOwner)
        {
            decimal sum = 0;
            List<ChargeItemDTO> chargeItems=null;

            foreach (var shareInfo in shareInfos)
            {
                sum += shareInfo.Area * shareInfo.Days;
            }
            foreach (var shareInfo in shareInfos)
            {
                var chargeItem = new ChargeItemDTO();
                chargeItem.Amount = amount * ((shareInfo.Area * shareInfo.Days)/sum);
                chargeItem.ExpenseId = expenseId;
                chargeItem.PersonId = shareInfo.PersonId;
                chargeItem.UnitId = shareInfo.UnitId;
                chargeItem.IsOwner = isOwner;
            }

            return chargeItems;
        }
    }
}
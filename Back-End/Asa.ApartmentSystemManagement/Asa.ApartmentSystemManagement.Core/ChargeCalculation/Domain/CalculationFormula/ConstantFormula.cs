using Asa.ApartmentSystemManagement.Core.BaseInfo.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asa.ApartmentSystemManagement.Core.ChargeCalculation.Domain.CalculationFormula
{
	public class ConstantFormula: IFormula
	{
        public List<ChargeItemDTO> Calculate(decimal amount, IEnumerable<ShareInfo> shareInfos, int expenseId, bool isOwner)
        {
            Dictionary<int, decimal> daysSum = new Dictionary<int, decimal>();
            List<ChargeItemDTO> chargeItems = new List<ChargeItemDTO>();
            foreach (var shareInfo in shareInfos)
            {
                if (!daysSum.ContainsKey(shareInfo.UnitId))
                    daysSum.Add(shareInfo.UnitId, 0);
                daysSum[shareInfo.UnitId] += shareInfo.Days;
            }
            foreach (var shareInfo in shareInfos)
            {
                var chargeItem = new ChargeItemDTO();
                chargeItem.Amount = amount * (shareInfo.Days / daysSum[shareInfo.UnitId]);
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

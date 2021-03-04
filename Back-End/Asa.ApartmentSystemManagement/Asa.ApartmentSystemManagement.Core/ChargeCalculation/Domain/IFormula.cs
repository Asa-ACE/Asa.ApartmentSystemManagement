using Asa.ApartmentSystemManagement.Core.BaseInfo.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asa.ApartmentSystemManagement.Core.ChargeCalculation.Domain
{
    public interface IFormula
    {
        List<ChargeItemDTO> Calculate(decimal amount, IEnumerable<ShareInfo> shareInfos, int expenseId, bool isOwner);

    }
}

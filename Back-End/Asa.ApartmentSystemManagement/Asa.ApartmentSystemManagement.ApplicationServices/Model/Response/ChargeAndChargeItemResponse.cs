using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asa.ApartmentSystemManagement.ApplicationServices.Model.Response
{
    public class ChargeAndChargeItemResponse
    {
        public ChargeResponse Charge { get; set; }
        IEnumerable<ChargeItemResponse> ChargeItems { get; set; }
        public ChargeAndChargeItemResponse(ChargeResponse charge , IEnumerable<ChargeItemResponse> chargeItems)
        {
            Charge = charge;
            ChargeItems = chargeItems;
        }
    }
}

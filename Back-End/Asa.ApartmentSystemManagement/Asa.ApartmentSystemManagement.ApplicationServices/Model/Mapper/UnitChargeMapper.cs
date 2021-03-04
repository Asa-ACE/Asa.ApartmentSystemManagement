using Asa.ApartmentSystemManagement.ApplicationServices.Model.Response;
using Asa.ApartmentSystemManagement.Core.BaseInfo.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Asa.ApartmentSystemManagement.ApplicationServices.Model.Mapper
{
    public static class UnitChargeMapper
    {
        public static ChargeItemResponse ToModel(this UnitChargeItemDTO unitChargeItem)
        {
            var model = new ChargeItemResponse
            {
                ExpenseName = unitChargeItem.ExpenseName,
                Amount = unitChargeItem.Amount,
                From = unitChargeItem.From,
                To = unitChargeItem.To,
                Id = unitChargeItem.ChargeItemId
            };
            return model;
        }

        public static IEnumerable<ChargeItemResponse> ToModel(this IEnumerable<UnitChargeItemDTO> unitChargeItems)
        {
            var model = unitChargeItems.Select(unitChargeItem => unitChargeItem.ToModel());
            return model;
        }

        public static UnitChargeResponse ToModel(this UnitChargeDTO unitCharge)
        {
            var model = new UnitChargeResponse
            {
                ChargeId = unitCharge.ChargeId,
                From = unitCharge.From,
                To = unitCharge.To,
                ChargeItems = unitCharge.ChargeItems.ToModel()
            };
            return model;
        }

        public static IEnumerable<UnitChargeResponse> ToModel(this IEnumerable<UnitChargeDTO> unitCharges)
        {
            var model = unitCharges.Select(unitCharge => unitCharge.ToModel());
            return model;
        }

    }
}

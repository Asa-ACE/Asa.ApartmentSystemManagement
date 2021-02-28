using Asa.ApartmentSystemManagement.Core.BaseInfo.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asa.ApartmentSystemManagement.Core.DTOs
{
	public class UnitChargeDTO
	{
		public int ChargeId { get; set; }
		public DateTime From { get; set; }
		public DateTime To { get; set; }
		public IEnumerable<ChargeItemDTO> ChargeItems { get; set; }
	}
}

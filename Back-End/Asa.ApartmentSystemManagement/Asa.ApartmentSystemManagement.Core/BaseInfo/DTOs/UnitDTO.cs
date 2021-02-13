using System;
using System.Collections.Generic;
using System.Text;

namespace Asa.ApartmentSystemManagement.Core.BaseInfo.DTOs
{
	public class UnitDTO
	{
		public int Id { get; set; }
		public int BuildingId { get; set; }
		public decimal Area { get; set; }
		public int UnitNumber { get; set; }
		public string Description { get; set; }
	}
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Asa.ApartmentSystemManagement.Core.BaseInfo.DTOs
{
	public class BuildingDTO
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int NumberOfUnits { get; set; }
        public string Address { get; set; }
    }
}

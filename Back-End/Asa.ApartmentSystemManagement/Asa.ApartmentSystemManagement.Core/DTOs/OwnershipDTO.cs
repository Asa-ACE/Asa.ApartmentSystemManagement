﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Asa.ApartmentSystemManagement.Core.BaseInfo.DTOs
{
	public class OwnershipDTO
	{
		public string UserName { get; set; }
		public int Id { get; set; }
		public int PersonId { get; set; }
		public int UnitId { get; set; }
		public DateTime From { get; set; }
		public DateTime? To { get; set; }
	}
}

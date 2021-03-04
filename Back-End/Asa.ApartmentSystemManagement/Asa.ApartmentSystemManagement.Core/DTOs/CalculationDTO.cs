using Asa.ApartmentSystemManagement.Core.BaseInfo.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asa.ApartmentSystemManagement.Core.BaseInfo.DTOs
{
	public class CalculationDTO
	{
		public int ExpenseId { get; set; }
		public string FormulaName { get; set; }
		public decimal Amount { get; set; }
		public bool IsForOwner { get; set; }
		public DateTime From { get; set; }
		public DateTime To { get; set; }
		public int BuildingId { get; set; }
	}
}

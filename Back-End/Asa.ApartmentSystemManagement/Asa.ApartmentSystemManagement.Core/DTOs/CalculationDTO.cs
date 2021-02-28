using Asa.ApartmentSystemManagement.Core.BaseInfo.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asa.ApartmentSystemManagement.Core.DTOs
{
	public class CalculationDTO
	{
		public int ExpenseId { get; set; }
		public string FormulaName { get; set; }
		public decimal Amount { get; set; }
		public IEnumerable<ShareInfo> MyProperty { get; set; }
	}
}

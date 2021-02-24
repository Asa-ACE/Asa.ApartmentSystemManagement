using System;
using System.Collections.Generic;
using System.Text;

namespace Asa.ApartmentSystemManagement.Core.BaseInfo.DTOs
{
    public class ExpenseCategoryDTO
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public int FormulaType { get; set; }
        public bool IsForOwner { get; set; }
    }
}

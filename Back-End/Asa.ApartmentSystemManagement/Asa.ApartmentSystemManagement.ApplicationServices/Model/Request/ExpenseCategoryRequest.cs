using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asa.ApartmentSystemManagement.ApplicationServices.Model.Request
{
    public class ExpenseCategoryRequest
    {
        public string Name { get; set; }
        public int FormulaType { get; set; }
        public bool IsForOwner { get; set; }
    }
}

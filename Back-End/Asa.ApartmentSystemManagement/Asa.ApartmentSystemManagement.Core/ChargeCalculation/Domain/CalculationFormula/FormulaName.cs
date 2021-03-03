using System;
using System.Collections.Generic;
using System.Text;

namespace Asa.ApartmentSystemManagement.Core.ChargeCalculation.Domain.CalculationFormula
{
    public class FormulaName
    {
        public FormulaName(string title, string typeName)
        {
            Title = title ?? throw new ArgumentNullException(nameof(title));
            TypeName = typeName ?? throw new ArgumentNullException(nameof(typeName));
        }

        public string Title { get; }
        public string TypeName { get; }
    }
}

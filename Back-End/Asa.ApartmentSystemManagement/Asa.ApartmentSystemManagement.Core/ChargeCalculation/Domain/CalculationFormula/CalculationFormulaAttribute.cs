
using System;
using System.Collections.Generic;
using System.Text;

namespace Asa.ApartmentSystemManagement.Core.ChargeCalculation.Domain.CalculationFormula
{
    [System.AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    sealed class CalculationFormulaAttribute : Attribute
    {
        public string FormulaTitle { get; }
        public CalculationFormulaAttribute(string formulaTitle)
        {
            FormulaTitle = formulaTitle;
        }
    }
}

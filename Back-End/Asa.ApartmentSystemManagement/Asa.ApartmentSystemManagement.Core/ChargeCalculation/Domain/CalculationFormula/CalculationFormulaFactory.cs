using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace ASa.ApartmentManagement.Core.ChargeCalculation.Domain.CalculationFormula
{
    public static class CalculationFormulaFactory
    {
        static Dictionary<string, string> formulaNames;
        static Dictionary<string, Type> formulaTypesDictionary;
        static Dictionary<string, IFormula> formulaInstances = new Dictionary<string, IFormula>();
        static readonly object lockToken = new object();
        public static List<string> GetAll()
        {
            if (formulaNames == null)
            {
                lock (lockToken)
                {
                    if (formulaNames == null)
                    {
                        ExtractFormulaNames();
                    }
                }
            }
            return formulaNames.Values.ToList();
        }

        private static void ExtractFormulaNames()
        {
            formulaNames = new Dictionary<string, string>();
            ExtractFormulaTypes();
            foreach (var type in formulaTypesDictionary.Values)
            {
                ExtractFormulaNameFromAttribute(type);
            }
        }

        private static void ExtractFormulaNameFromAttribute(Type type)
        {
            var attributes = type.GetCustomAttributes(false);
            if (attributes != null)
            {
                foreach (var attribute in attributes)
                {
                    if (attribute is CalculationFormulaAttribute attr)
                    {
                        formulaNames.Add(type.FullName, attr.FormulaTitle);
                        break;
                    }
                }
            }
        }

        private static void ExtractFormulaTypes()
        {
            var domainAssembly = typeof(CalculationFormulaFactory).Assembly;
            var allTypes = domainAssembly.GetTypes();
            formulaTypesDictionary = new Dictionary<string, Type>();
            foreach (var type in allTypes)
            {
                var allInterfaces = type.GetInterfaces();
                if (allInterfaces != null && allInterfaces.Any(x => x == typeof(IFormula)))
                {
                    formulaTypesDictionary.Add(type.FullName, type);
                }
            }

        }

        public static IFormula Create(string typeFullName)
        {
            if (formulaInstances.ContainsKey(typeFullName))
            {
                return formulaInstances[typeFullName];
            }
            else
            {
                return CreateFormulaInstance(typeFullName);
            }
        }

        private static IFormula CreateFormulaInstance(string typeFullName)
        {
            if (formulaTypesDictionary.ContainsKey(typeFullName))
            {
                var formulaType = formulaTypesDictionary[typeFullName];
                var formula = Activator.CreateInstance(formulaType) as IFormula;
                formulaInstances.Add(typeFullName, formula);
                return formula;
            }
            throw new InvalidOperationException($"Cannot find a formula with type {typeFullName}.");
        }
    }
}

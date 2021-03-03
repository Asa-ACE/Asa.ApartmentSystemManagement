using Asa.ApartmentSystemManagement.ApplicationServices.Model.Request;
using Asa.ApartmentSystemManagement.ApplicationServices.Model.Response;
using Asa.ApartmentSystemManagement.Core.BaseInfo.DTOs;
using ASa.ApartmentManagement.Core.ChargeCalculation.Domain.CalculationFormula;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asa.ApartmentSystemManagement.ApplicationServices.Model.Mapper
{
    public static class FormulaTypeMapper
    {
        public static FormulaResponse ToModel(this FormulaName formula)
        {
            FormulaResponse model = new FormulaResponse();
            model.Title = formula.Title;
            model.TypeName = formula.TypeName;
            return model;
        }

        public static IEnumerable<FormulaResponse> ToModel(this IEnumerable<FormulaName> formulas)
        {
            List<FormulaResponse> model = new List<FormulaResponse>();
            foreach (var formula in formulas)
            {
                model.Add(formula.ToModel());
            }
            return model;
        }
    }
}

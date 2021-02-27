using Asa.ApartmentSystemManagement.ApplicationServices.Model.Response;
using Asa.ApartmentSystemManagement.Core.BaseInfo.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asa.ApartmentSystemManagement.ApplicationServices.Model.Mapper
{
    public static class ExpenseMapper
    {
        public static ExpenceCategoryResponse ToModel(this ExpenseCategoryDTO expense)
        {
            ExpenceCategoryResponse model = new ExpenceCategoryResponse();
            model.CategoryId = expense.CategoryId;
            model.FormulaType = expense.FormulaType;
            model.IsForOwner = expense.IsForOwner;
            model.Name = expense.Name;
            return model;
        }

        public static IEnumerable<ExpenceCategoryResponse> ToModel(this IEnumerable<ExpenseCategoryDTO> expenses)
        {
            List<ExpenceCategoryResponse> model = new List<ExpenceCategoryResponse>();
            foreach (var expense in expenses)
            {
                model.Add(expense.ToModel());
            }
            return model;
        }
    }
}

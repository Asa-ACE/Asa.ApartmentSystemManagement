using Asa.ApartmentSystemManagement.ApplicationServices.Model.Response;
using Asa.ApartmentSystemManagement.Core.BaseInfo.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asa.ApartmentSystemManagement.ApplicationServices.Model.Mapper
{
    public static class ExpenseMapper
    {
        public static ExpenseCategoryResponse ToModel(this ExpenseCategoryDTO expense)
        {
            ExpenseCategoryResponse model = new ExpenseCategoryResponse();
            model.CategoryId = expense.CategoryId;
            model.FormulaType = expense.FormulaType;
            model.IsForOwner = expense.IsForOwner;
            model.Name = expense.Name;
            return model;
        }

        public static IEnumerable<ExpenseCategoryResponse> ToModel(this IEnumerable<ExpenseCategoryDTO> expenses)
        {
            List<ExpenseCategoryResponse> model = new List<ExpenseCategoryResponse>();
            foreach (var expense in expenses)
            {
                model.Add(expense.ToModel());
            }
            return model;
        }

        public static ExpenseResponse ToExpenseModel(this ExpenseDTO expense)
        {
            ExpenseResponse model = new ExpenseResponse();
            model.CategoryId = expense.CategoryId;
            model.BuildingId = expense.BuildingId;
            model.Amount = expense.Amount;
            model.ExpenseId = expense.ExpenseId;
            model.From = expense.From;
            model.To = expense.To;
            model.Name = expense.Name;
            return model;
        }

        public static IEnumerable<ExpenseResponse> ToExpenseModel(this IEnumerable<ExpenseDTO> expenses)
        {
            List<ExpenseResponse> model = new List<ExpenseResponse>();
            foreach (var expense in expenses)
            {
                model.Add(expense.ToExpenseModel());
            }
            return model;
        }
    }
}

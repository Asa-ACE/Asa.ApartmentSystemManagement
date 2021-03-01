﻿using Asa.ApartmentSystemManagement.API.Tools;
using Asa.ApartmentSystemManagement.ApplicationServices;
using Asa.ApartmentSystemManagement.ApplicationServices.Model.Request;
using Asa.ApartmentSystemManagement.ApplicationServices.Model.Response;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Asa.ApartmentSystemManagement.API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class BuildingController : ControllerBase
    {
        private BaseInfoApplicationService _baseInfoApplicationService;
        private ChargeApplicationService _chargeApplicationService;

        public BuildingController(BaseInfoApplicationService baseInfoApplicationService , ChargeApplicationService chargeApplicationService)
        {
            _baseInfoApplicationService = baseInfoApplicationService;
            _chargeApplicationService = chargeApplicationService;
        }

        //building
        [HttpGet]
        public async Task<IActionResult> GetBuildings()
        {
            var userId = Convert.ToInt32(HttpContext.Items["User"]);
            var buildings = await _baseInfoApplicationService.GetBuildingsAsync(userId);
            return Ok(buildings);
        }

        [HttpPost]
        public async Task<IActionResult> AddBuilding([FromBody] BuildingRequest building)
        {
            var userId = Convert.ToInt32(HttpContext.Items["User"]);
            var name = building.Name;
            var numberOfUnits = building.NumberOfUnits;
            var address = building.Address;
            var id = await _baseInfoApplicationService.CreateBuildingAsync(name, numberOfUnits, address);
            return Ok(id);
        
        }

        [HttpPatch]
        [Route("{id:int}")]
        public async Task<IActionResult> ChangeBuildingName([FromRoute] int id, [FromQuery] string newName)
        {
            await _baseInfoApplicationService.UpdateBuildingNameAsync(id, newName);
            return Ok();
        }

        //unit
        [HttpGet]
        [Route("{buildingId:int}/Units")]
        public async Task<IActionResult> GetUnits([FromRoute] int buildingId)
        {
            var units = await _baseInfoApplicationService.GetUnitsByBuildingIdAsync(buildingId);
            return Ok(units);
        }

        [HttpPost]
        [Route("{buildingId:int}/Units")]
        public async Task<IActionResult> AddUnit([FromRoute] int buildingId, [FromBody] UnitRequest unit)
        {
            await _baseInfoApplicationService.CreateUnitAsync(buildingId, unit.Area, unit.UnitNumber, unit.Description);
            return Ok();
        }

        //owner
        [HttpGet]
        [Route("{buildingId:int}/Units/{unitId:int}/Owner")]
        public async Task<IActionResult> GetOwners([FromRoute] int unitId)
        {
            var units = await _baseInfoApplicationService.GetOwnersByUnitIdAsync(unitId);
            return Ok(units);
        }

        [HttpPost]
        [Route("{buildingId:int}/Units/{unitId:int}/Owner")]
        public async Task<IActionResult> AddOwner([FromRoute] int unitId, [FromBody] OwnerRequest owner)
        {
            var id = await _baseInfoApplicationService.CreateOwnershipAsync(unitId, owner.PersonId, owner.From, owner.To);
            return Ok(id);
        }

        [HttpPut]
        [Route("{buildingId:int}/Units/{unitId:int}/Owner/{ownerId:int}")]
        public async Task<IActionResult> ChangeOwner([FromRoute] int ownershipId, [FromBody] OwnerRequest owner)
        {
            await _baseInfoApplicationService.ChangeOwnerAsync(ownershipId, owner);
            return Ok();
        }

        //tenant
        [HttpGet]
        [Route("{buildingId:int}/Units/{unitId:int}/Tenant")]
        public async Task<IActionResult> GetTenants([FromRoute] int unitId)
        {
            var units = await _baseInfoApplicationService.GetTenantsByUnitIdAsync(unitId);
            return Ok(units) ;
        }

        [HttpPost]
        [Route("{buildingId:int}/Units/{unitId:int}/Tenant")]
        public async Task<IActionResult> AddTenant([FromRoute] int unitId, [FromBody] TenantRequest tenant)
        {
            var id = await _baseInfoApplicationService.CreateTenancyAsync(unitId , tenant.PersonId , tenant.From , tenant.To , tenant.NumberOfPeople);
            return Ok(id);
        }

        [HttpPut]
        [Route("{buildingId:int}/Units/{unitId:int}/Tenant/{tenantId:int}")]
        public async Task<IActionResult> ChangeTenant([FromRoute] int tenantId, [FromBody] TenantRequest tenant)
        {
            await _baseInfoApplicationService.ChangeTenantAsync(tenantId, tenant);
            return Ok();
        }
        
        //ExpenseCategory
        [HttpGet]
        [Route("ExpenseCategory")]
        public async Task<IActionResult> GetExpenseCategories()
        {
            var expenseCategories =  await _baseInfoApplicationService.GetExpenseCategoriesAsync();
            return Ok(expenseCategories);
        }

        [HttpPost]
        [Route("ExpenseCategory")]
        public async Task<IActionResult> AddExpenseCategory([FromBody] ExpenseCategoryRequest expenseCategory)
        {
            var id = await _baseInfoApplicationService.CreateExpenseCategoryAsync(expenseCategory);
            return Ok(id);
        }

        [HttpPut]
        [Route("ExpenseCategory/{categoryId:int}")]
        public async Task<IActionResult> ChangeExpenseCategory([FromRoute] int categoryId , [FromBody] ExpenseCategoryRequest expenseCategory)
        {
            await _baseInfoApplicationService.ChangeExpenseCategoryAsync(categoryId, expenseCategory); 
            return Ok();
        }

        //Expance
        [HttpGet]
        [Route("{buildingId:int}/Expense")]
        public IEnumerable<ExpenseResponse> GetExpenses([FromRoute] int buildingId)
        {
            var expenses = _baseInfoApplicationService.GetExpenses(buildingId);
            return expenses;
        }
        [HttpPost]
        [Route("{buildingId:int}/Expense")]
        public void AddExpense([FromRoute] int buildingId , ExpenseRequest expense)
        {
            _baseInfoApplicationService.AddExpense(buildingId, expense.CategoryId, expense.From, expense.To, expense.Amount, expense.Name);
        }
        [HttpPut]
        [Route("{buildingId:int}/Expense/{expenseId:int}")]
        public void ChangeExpense([FromRoute] int buildingId , [FromRoute] int expenseId , ExpenseRequest expense)
        {
            _baseInfoApplicationService.ChangeExpense(expenseId, expense.CategoryId, expense.From, expense.To, expense.Amount, expense.Name);
        }
        [HttpDelete]
        [Route("{buildingId:int}/Expense/{expenseId:int}")]
        public void DeleteExpense([FromRoute] int expenseId)
        {
            _baseInfoApplicationService.DeleteExpense(expenseId);
        }


    }
}

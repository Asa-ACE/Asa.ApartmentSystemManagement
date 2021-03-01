using Asa.ApartmentSystemManagement.API.Interfaces.ApplicationServices;
using Asa.ApartmentSystemManagement.API.Model;
using Asa.ApartmentSystemManagement.API.Model.Request;
using Asa.ApartmentSystemManagement.API.Model.Response;
using Asa.ApartmentSystemManagement.API.Tools;
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
        public async Task<IActionResult> AddBuilding([FromBody] BuildingRequest buildingInfo)
        {
            var userId = Convert.ToInt32(HttpContext.Items["User"]);
            var name = buildingInfo.Name;
            var numberOfUnits = buildingInfo.NumberOfUnits;
            var address = buildingInfo.Address;
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
        public async Task<IActionResult> AddUnit([FromRoute] int buildingId, [FromBody] UnitRequest unitInfo)
        {
            await _baseInfoApplicationService.CreateUnitAsync(buildingId, unitInfo.Area, unitInfo.UnitNumber, unitInfo.Description);
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
        public async Task<IActionResult> AddOwner([FromRoute] int unitId, [FromBody] OwnerRequest ownerInfo)
        {
            var id = await _baseInfoApplicationService.CreateOwnershipAsync(unitId, ownerInfo.PersonId, ownerInfo.From, ownerInfo.To);
            return Ok(id);
        }

        [HttpPut]
        [Route("{buildingId:int}/Units/{unitId:int}/Owner/{ownerId:int}")]
        public async Task<IActionResult> ChangeOwnerInfo([FromRoute] int ownershipId, [FromBody] OwnerRequest ownerInfo)
        {
            await _baseInfoApplicationService.ChangeOwnerAsync(ownershipId, ownerInfo);
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
        public async Task<IActionResult> AddTenant([FromRoute] int unitId, [FromBody] TenantRequest tenantInfo)
        {
            var id = await _baseInfoApplicationService.CreateTenancyAsync(unitId , tenantInfo.PersonId , tenantInfo.From , tenantInfo.To , tenantInfo.NumberOfPeople);
            return Ok(id);
        }

        [HttpPut]
        [Route("{buildingId:int}/Units/{unitId:int}/Tenant/{tenantId:int}")]
        public async Task<IActionResult> ChangeTenantInfo([FromRoute] int tenantId, [FromBody] TenantRequest tenantInfo)
        {
            await _baseInfoApplicationService.ChangeTenantAsync(tenantId, tenantInfo);
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
        public async Task<IActionResult> AddExpenseCategory([FromBody] ExpenseCategoryRequest expenseCategoryInfo)
        {
            var id = await _baseInfoApplicationService.(expenseCategoryInfo.Name, expenseCategoryInfo.FormulaType, expenseCategoryInfo.IsForOwner);
        }

        [HttpPut]
        [Route("ExpenseCategory/{categoryId:int}")]
        public void ChangeExpenseCategoryInfo([FromRoute] int categoryId , [FromBody] ExpenseCategoryRequest expenseCategoryInfo)
        {
            _baseInfoApplicationService.ChangeExpenseCategoryInfo(categoryId, expenseCategoryInfo.Name, expenseCategoryInfo.FormulaType, expenseCategoryInfo.IsForOwner);
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
        public void AddExpense([FromRoute] int buildingId , ExpenseRequest expenseInfo)
        {
            _baseInfoApplicationService.AddExpense(buildingId, expenseInfo.CategoryId, expenseInfo.From, expenseInfo.To, expenseInfo.Amount, expenseInfo.Name);
        }
        [HttpPut]
        [Route("{buildingId:int}/Expense/{expenseId:int}")]
        public void ChangeExpenseInfo([FromRoute] int buildingId , [FromRoute] int expenseId , ExpenseRequest expenseInfo)
        {
            _baseInfoApplicationService.ChangeExpenseInfo(expenseId, expenseInfo.CategoryId, expenseInfo.From, expenseInfo.To, expenseInfo.Amount, expenseInfo.Name);
        }
        [HttpDelete]
        [Route("{buildingId:int}/Expense/{expenseId:int}")]
        public void DeleteExpense([FromRoute] int expenseId)
        {
            _baseInfoApplicationService.DeleteExpense(expenseId);
        }


    }
}

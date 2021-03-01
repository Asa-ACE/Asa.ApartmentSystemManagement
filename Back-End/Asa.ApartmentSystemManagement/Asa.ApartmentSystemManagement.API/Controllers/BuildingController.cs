using Asa.ApartmentSystemManagement.API.Interfaces.ApplicationServices;
using Asa.ApartmentSystemManagement.API.Model;
using Asa.ApartmentSystemManagement.API.Model.Request;
using Asa.ApartmentSystemManagement.API.Model.Response;
using Asa.ApartmentSystemManagement.API.Tools;
using Asa.ApartmentSystemManagement.ApplicationServices;
using Asa.ApartmentSystemManagement.ApplicationServices.Model.Request;
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
        public IEnumerable<TenantResponse> GetTenants([FromRoute] int unitId)
        {
            var units = _baseInfoApplicationService.GetTenants(unitId);
            return units;
        }
        [HttpPost]
        [Route("{buildingId:int}/Units/{unitId:int}/Tenant")]
        public void AddTenant([FromRoute] int unitId, [FromBody] TenantRequest tenantInfo)
        {
            _baseInfoApplicationService.AddTenant(unitId , tenantInfo.PersonId , tenantInfo.From , tenantInfo.To , tenantInfo.NumberOfPeople);
        }
        [HttpPut]
        [Route("{buildingId:int}/Units/{unitId:int}/Tenant/{tenantId:int}")]
        public void ChangeTenantInfo([FromRoute] int tenantId, [FromBody] TenantRequest tenantInfo)
        {
            _baseInfoApplicationService.ChangeTenantInfo(tenantId, tenantInfo.PersonId, tenantInfo.From, tenantInfo.To, tenantInfo.NumberOfPeople);
        }

        //ExpenceCategory
        [HttpGet]
        [Route("ExpenceCategory")]
        public IEnumerable<ExpenceCategoryResponse> GetExpenceCategories()
        {
            var userId = Convert.ToInt32(HttpContext.Items["User"]);
            var expenseCategories =  _baseInfoApplicationService.GetExpenceCategories(userId);
            return expenseCategories;
        }
        [HttpPost]
        [Route("ExpenceCategory")]
        public void AddExpenceCategory([FromBody] ExpenceCategoryRequest expenceCategoryInfo)
        {
            _baseInfoApplicationService.AddExpenceCategory(expenceCategoryInfo.Name, expenceCategoryInfo.FormulaType, expenceCategoryInfo.IsForOwner);
        }
        [HttpPut]
        [Route("ExpenceCategory/{categoryId:int}")]
        public void ChangeExpenceCategoryInfo([FromRoute] int categoryId , [FromBody] ExpenceCategoryRequest expenceCategoryInfo)
        {
            _baseInfoApplicationService.ChangeExpenceCategoryInfo(categoryId, expenceCategoryInfo.Name, expenceCategoryInfo.FormulaType, expenceCategoryInfo.IsForOwner);
        }

        //Expance
        [HttpGet]
        [Route("{buildingId:int}/Expence")]
        public IEnumerable<ExpenceResponse> GetExpences([FromRoute] int buildingId)
        {
            var expences = _baseInfoApplicationService.GetExpences(buildingId);
            return expences;
        }
        [HttpPost]
        [Route("{buildingId:int}/Expence")]
        public void AddExpence([FromRoute] int buildingId , ExpenseRequest expenseInfo)
        {
            _baseInfoApplicationService.AddExpence(buildingId, expenseInfo.CategoryId, expenseInfo.From, expenseInfo.To, expenseInfo.Amount, expenseInfo.Name);
        }
        [HttpPut]
        [Route("{buildingId:int}/Expence/{expenceId:int}")]
        public void ChangeExpenceInfo([FromRoute] int buildingId , [FromRoute] int expenceId , ExpenseRequest expenseInfo)
        {
            _baseInfoApplicationService.ChangeExpenceInfo(expenceId, expenseInfo.CategoryId, expenseInfo.From, expenseInfo.To, expenseInfo.Amount, expenseInfo.Name);
        }
        [HttpDelete]
        [Route("{buildingId:int}/Expence/{expenceId:int}")]
        public void DeleteExpence([FromRoute] int expenceId)
        {
            _baseInfoApplicationService.DeleteExpence(expenceId);
        }


    }
}

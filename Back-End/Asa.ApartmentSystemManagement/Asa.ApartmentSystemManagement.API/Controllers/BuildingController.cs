using Asa.ApartmentSystemManagement.API.Interfaces.ApplicationServices;
using Asa.ApartmentSystemManagement.API.Model;
using Asa.ApartmentSystemManagement.API.Model.Request;
using Asa.ApartmentSystemManagement.API.Model.Response;
using Asa.ApartmentSystemManagement.API.Tools;
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
        public BuildingController(IBaseInfoApplicationService baseInfoApplicationService , IChargeApplicationService chargeApplicationService)
        {
            _baseInfoApplicationService = baseInfoApplicationService;
            _chargeApplicationService = chargeApplicationService;
        }

        //building
        [HttpGet]
        public IEnumerable<BuildingResponse> GetBuildings()
        {
            var userId = Convert.ToInt32(HttpContext.Items["User"]);
            var buildings = _baseInfoApplicationService.GetBuildings(userId);
            return buildings;
        }
        [HttpPost]
        public void AddBuilding([FromBody] BuildingRequest buildingInfo)
        {
            var userId = Convert.ToInt32(HttpContext.Items["User"]);
            var name = buildingInfo.Name;
            var numberOfUnits = buildingInfo.NumberOfUnits;
            _baseInfoApplicationService.CreateBuilding(name, numberOfUnits);
        }
        [HttpPatch]
        [Route("{id:int}")]
        public void ChangeBuildingName([FromRoute] int id, [FromQuery] string newName)
        {
            _baseInfoApplicationService.ChangeBuildingName(id, newName);
        }

        //unit
        [HttpGet]
        [Route("{buildingId:int}/Units")]
        public IEnumerable<UnitResponse> GetUnits([FromRoute] int buildingId)
        {
            var units = _baseInfoApplicationService.GetUnits(buildingId);
            return units;
        }
        [HttpPost]
        [Route("{buildingId:int}/Units")]
        public void AddUnit([FromRoute] int buildingId, [FromBody] UnitRequest unitInfo)
        {
            _baseInfoApplicationService.CreateUnit(buildingId, unitInfo.Area, unitInfo.UnitNumber, unitInfo.Description);
        }

        //owner
        [HttpGet]
        [Route("{buildingId:int}/Units/{unitId:int}/Owner")]
        public IEnumerable<OwnerResponse> GetOwners([FromRoute] int unitId)
        {
            var units = _baseInfoApplicationService.GetOwners(unitId);
            return units;
        }
        [HttpPost]
        [Route("{buildingId:int}/Units/{unitId:int}/Owner")]
        public void AddOwner([FromRoute] int unitId, [FromBody] OwnerRequest ownerInfo)
        {
            _baseInfoApplicationService.AddOwner(unitId, ownerInfo.PersonId, ownerInfo.From, ownerInfo.To);
        }
        [HttpPut]
        [Route("{buildingId:int}/Units/{unitId:int}/Owner/{ownerId:int}")]
        public void ChangeOwnerInfo([FromRoute] int ownerId, [FromBody] OwnerRequest ownerInfo)
        {
            _baseInfoApplicationService.ChangeOwnerInfo(ownerId, ownerInfo.PersonId, ownerInfo.From, ownerInfo.To);
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

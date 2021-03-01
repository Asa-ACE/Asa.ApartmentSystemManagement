
using Asa.ApartmentSystemManagement.ApplicationServices.Model.Mapper;
using Asa.ApartmentSystemManagement.ApplicationServices.Model.Request;
using Asa.ApartmentSystemManagement.ApplicationServices.Model.Response;
using Asa.ApartmentSystemManagement.Core.BaseInfo.DTOs;
using Asa.ApartmentSystemManagement.Core.BaseInfo.Gateways;
using Asa.ApartmentSystemManagement.Core.BaseInfo.Managers;
using Asa.ApartmentSystemManagement.Infra.DataGateways;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Asa.ApartmentSystemManagement.ApplicationServices
{
    public class BaseInfoApplicationService
    {
        ITableGatewayFactory _tableGatewayFactory;
        BuildingManager _buildingManager;
        ExpenseManager _expenseManager;
        PersonManager _personManager;

        public BaseInfoApplicationService(string connectionString)
        {
            _tableGatewayFactory = new SqlTableGatewayFactory(connectionString);
            _buildingManager = new BuildingManager(_tableGatewayFactory);
            _expenseManager = new ExpenseManager(_tableGatewayFactory);
            _personManager = new PersonManager(_tableGatewayFactory);
        }

        public async Task<int> CreateBuildingAsync(string name, int numberofUnits, string address)
        {
            var buildingDto = new BuildingDTO { Name = name, NumberOfUnits = numberofUnits, Address = address };
            await _buildingManager.AddBuildingAsync(buildingDto);
            return buildingDto.Id;
        }

        public async Task<int> CreateUnitAsync(int buildingId, decimal area, int number, string description)
        {
            var unitDto = new UnitDTO { BuildingId = buildingId, Area = area, UnitNumber = number, Description = description };
            await _buildingManager.AddUnitAsync(unitDto);
            return unitDto.Id;
        }

        public async Task<int> CreateOwnershipAsync(int personId, int unitId, DateTime from, DateTime? to)
        {
            var ownerDto = new OwnershipDTO { PersonId = personId, UnitId = unitId, From = from, To = to };
            await _buildingManager.AddOwnershipAsync(ownerDto);
            return ownerDto.Id;
        }

        public async Task<int> CreateExpenseCategoryAsync(ExpenseCategoryRequest newExpenseCategory)
        {
            var expenseCategory = newExpenseCategory.ToDTO();
            await _buildingManager.AddExpenseCategoryAsync(expenseCategory);
            return expenseCategory.id;
        }

        public async Task<int> CreateTenancyAsync(int personId, int unitId, DateTime from, DateTime? to, int numberOfPeople)
        {
            var tenantDto = new TenancyDTO { PersonId = personId, UnitId = unitId, From = from, To = to, NumberOfPeople = numberOfPeople };
            await _buildingManager.AddTenancyAsync(tenantDto).ConfigureAwait(false);
            return tenantDto.TenancyId;
        }

        public async Task<BuildingDTO> GetBuildingByIdAsync(int id)
        {
            return await _buildingManager.GetBuildingByIdAsync(id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<BuildingResponse>> GetBuildingsAsync(int userId)
        {
            var buildings = await _buildingManager.GetBuildingsAsync(userId);
            return buildings.ToModel();
        }

        public async Task<UnitDTO> GetUnitByIdAsync(int id)
        {
            return await _buildingManager.GetUnitByIdAsync(id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<UnitResponse>> GetUnitsByBuildingIdAsync(int buildingId)
        {
            var units = await _buildingManager.GetUnitsByBuildingIdAsync(buildingId);
            return units.ToModel();
        }

        public async Task<IEnumerable<OwnerResponse>> GetOwnersByUnitIdAsync(int unitId)
        {
            var owners = await _buildingManager.GetOwnersByUnitIdAsync(unitId);
            return owners.ToOwnerModel();
        }

        public async Task<IEnumerable<TenantResponse>> GetTenantsByUnitIdAsync(int unitId)
        {
            var tenants = await _buildingManager.GetTenantsByUnitIdAsync(unitId);
            return tenants.ToTenantModel();
        }

        public async Task UpdateBuildingNameAsync(int id, string name)
        {
            await _buildingManager.UpdateBuildingNameAsync(id, name).ConfigureAwait(false);
        }

        public async Task ChangeOwnerAsync(int ownershipId , OwnerRequest newOwner)
        {
            var owner = newOwner.ToDTO();
            owner.Id = ownershipId;
            await _buildingManager.UpdateOwnershipAsync(owner).ConfigureAwait(false);
        }

        public async Task ChangeTenantAsync(int tenantId, TenantRequest newTenant)
        {
            var tenant = newTenant.ToDTO();
            tenant.TenancyId = tenantId;
            await _buildingManager.UpdateTenancyAsync(tenant).ConfigureAwait(false);
        }

        public async Task RemoveBuildingAsync(int buildingId)
        {
            await _buildingManager.RemoveBuildingAsync(buildingId).ConfigureAwait(false);
        }

        public async Task<IEnumerable<ExpenseCategoryResponse>> GetExpenseCategoriesAsync()
        {
            var expenses = await _expenseManager.GetExpenseCategoriesAsync();
            return expenses.ToModel();
        }

        public async Task<IEnumerable<ExpenseResponse>> GetExpensesAsync(int buildingId)
        {
            var expense = await _expenseManager.GetExpensesAsync(buildingId);
            return expense.ToExpenseModel();
        }

        public async Task<int> CreateExpense(ExpenseRequest newExpense)
        {
            var expense = newExpense.ToDTO();
            await _expenseManager.AddExpense(expense);
            return expense.ExpenseId;
        }

        public async Task<IEnumerable<UnitResponse>> GetOwnedUnitsAsync(int userId)
        {
            var units = await _buildingManager.GetOwnedUnitsAsync(userId);
            return units.ToModel();
        }

        public async Task<IEnumerable<UnitResponse>> GetRentedUnitsAsync(int userId)
        {
            var units = await _buildingManager.GetRentedUnitsAsync(userId);
            return units.ToModel();
        }
    }
}


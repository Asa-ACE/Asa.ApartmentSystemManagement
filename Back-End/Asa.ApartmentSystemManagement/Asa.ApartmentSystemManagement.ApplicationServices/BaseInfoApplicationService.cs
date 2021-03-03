
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

        public async Task<int> CreateUnitAsync(int buildingId, decimal area, int number)
        {
            var unitDto = new UnitDTO { BuildingId = buildingId, Area = area, UnitNumber = number};
            await _buildingManager.AddUnitAsync(unitDto);
            return unitDto.Id;
        }

        public async Task<int> CreateOwnershipAsync( int unitId, string personName, DateTime from, DateTime? to)
        {
            var ownerDto = new OwnershipDTO { UserName = personName, UnitId = unitId, From = from, To = to };
            await _buildingManager.AddOwnershipAsync(ownerDto);
            return ownerDto.Id;
        }

        public async Task CreateAdminAsync(int userId, int buildingId)
        {
            await _buildingManager.AddAdminAsync(userId, buildingId);
        }

        public async Task<int> CreateExpenseCategoryAsync(ExpenseCategoryRequest newExpenseCategory)
        {
            var expenseCategory = newExpenseCategory.ToDTO();
            await _buildingManager.AddExpenseCategoryAsync(expenseCategory);
            return expenseCategory.CategoryId;
        }

        public async Task<int> CreateTenancyAsync(int unitId , string personName , DateTime from, DateTime? to, int numberOfPeople)
        {
            var tenantDto = new TenancyDTO { UserName = personName, UnitId = unitId, From = from, To = to, NumberOfPeople = numberOfPeople };
            await _buildingManager.AddTenancyAsync(tenantDto).ConfigureAwait(false);
            return tenantDto.TenancyId;
        }

        public async Task<BuildingResponse> GetBuildingByIdAsync(int id)
        {
            var building =  await _buildingManager.GetBuildingByIdAsync(id).ConfigureAwait(false);
            return building.ToModel();
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

        public async Task ChangeOwnerAsync(ChangeOwnerRequest newOwner)
        {
            var owner = newOwner.ToDTO();
            await _buildingManager.UpdateOwnershipAsync(newOwner.OldFrom, owner).ConfigureAwait(false);
        }

        public async Task ChangeTenantAsync(ChangeTenantRequest newTenant)
        {
            var tenant = newTenant.ToDTO();
            await _buildingManager.UpdateTenancyAsync(newTenant.OldFrom, tenant).ConfigureAwait(false);
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

        public async Task<int> CreateExpenseAsync(int buildingId , ExpenseRequest newExpense)
        {
            var expense = newExpense.ToDTO();
            expense.BuildingId = buildingId;
            await _expenseManager.AddExpenseAsync(expense);
            return expense.ExpenseId;
        }

        public async Task ChangeExpenseCategoryAsync(int categoryId, ExpenseCategoryRequest newExpenseCategory)
        {
            var expenseCategory = newExpenseCategory.ToDTO();
            expenseCategory.CategoryId = categoryId;
            await _expenseManager.UpdateExpenseCategoryAsync(expenseCategory);
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

        public async Task ChangeExpenseAsync(int buildingId, int expenseId, ExpenseRequest newExpense)
        {
            var expense = newExpense.ToDTO();
            expense.ExpenseId = expenseId;
            expense.BuildingId = buildingId;
            await _expenseManager.UpdateExpenseAsync(expense);
        }

        public async Task DeleteExpenseAsync(int expenseId)
        {
            await _expenseManager.DeleteExpenseAsync(expenseId);
        }

    }
}


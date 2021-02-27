using Asa.ApartmentSystemManagement.Core.BaseInfo.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Asa.ApartmentSystemManagement.Core.BaseInfo.Gateways
{
	public interface IOwnershipTableGateway
	{
		Task<int> InsertOwnershipAsync(OwnershipDTO ownership);
		Task UpdateOwnershipAsync(OwnershipDTO ownership);
		Task<IEnumerable<ShareInfo>> GetOwnerPaymentsAsync(int UnitId, DateTime from, DateTime to);
        Task<IEnumerable<ShareInfo>> GetOwnerPayments(int unitId, DateTime from, DateTime to);
    }
}
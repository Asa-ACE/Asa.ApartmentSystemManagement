﻿using Asa.ApartmentSystemManagement.Core.BaseInfo.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Asa.ApartmentSystemManagement.Core.BaseInfo.Gateways
{
	public interface IOwnershipTableGateway
	{
		Task<int> InsertOwnershipAsync(OwnershipDTO ownership);
		Task UpdateOwnershipAsync(OwnershipDTO ownership);
		Task<IEnumerable<PaymentDTO>> GetOwnerPayments(int UnitId, DateTime from, DateTime to);
	}
}
﻿using Asa.ApartmentSystemManagement.Core.BaseInfo.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Asa.ApartmentSystemManagement.Core.BaseInfo.Gateways
{
    public interface ITenancyTableGateway
    {
        Task<int> InsertTenancyAsync(TenancyDTO tenancy);
        Task UpdateTenancyAsync(DateTime oldFrom, TenancyDTO tenancy);

        Task<IEnumerable<ShareInfo>> GetTenantShareInfoAsync(int buildingId, DateTime from, DateTime to);
	}
}

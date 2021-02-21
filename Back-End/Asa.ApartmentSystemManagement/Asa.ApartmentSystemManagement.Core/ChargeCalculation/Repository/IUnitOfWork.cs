using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Asa.ApartmentSystemManagement.Core.ChargeCalculation.Repository
{
    public interface IUnitOfWork
    {
        Task Commit();
        IBuildingRepository BuildingRepository { get; }
        IChargeRepository ChargeRepository { get; }
        IExpenseRepository ExpenseRepository { get; }
    }
}

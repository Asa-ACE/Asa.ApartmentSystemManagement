using ASa.ApartmentManagement.Core.ChargeCalculation.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Asa.ApartmentSystemManagement.Core.ChargeCalculation.Repository
{
    public interface IExpenseRepository
    {
        Task<int> AddExpanse(Expens expens);
        Task<Expens> GetExpensByID(int Expens);

    }
}

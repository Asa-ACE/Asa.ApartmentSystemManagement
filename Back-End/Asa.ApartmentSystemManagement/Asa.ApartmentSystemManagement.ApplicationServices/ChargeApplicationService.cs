using Asa.ApartmentSystemManagement.Core.ChargeCalculation.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Asa.ApartmentSystemManagement.ApplicationServices
{
    public class ChargeApplicationService
    {
        IUnitOfWorkFactory _unitOfWorkFactory;
        public ChargeApplicationService(IUnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory ?? throw new ArgumentNullException(nameof(unitOfWorkFactory));
        }

        public async Task CalculateCharge(DateTime from, DateTime to)
        {
            throw new NotImplementedException();
        }
    }
}

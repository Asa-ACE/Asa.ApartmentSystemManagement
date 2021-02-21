﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Asa.ApartmentSystemManagement.Core.ChargeCalculation.Repository
{
    public interface IUnitOfWorkFactory
    {
        IUnitOfWork Create();
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asa.ApartmentSystemManagement.API.Model.Request
{
    public class OwnerRequest
    {
        public int PersonId { get; set; }
        public DateTime From { get; set; }
        public DateTime? To { get; set; }
    }
}

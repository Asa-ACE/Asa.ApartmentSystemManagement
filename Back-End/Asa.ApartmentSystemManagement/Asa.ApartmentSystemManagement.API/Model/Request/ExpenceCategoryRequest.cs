﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asa.ApartmentSystemManagement.API.Model.Request
{
    public class ExpenceCategoryRequest
    {
        public string Name { get; set; }
        public int FormulaType { get; set; }
        public bool IsForOwner { get; set; }
    }
}
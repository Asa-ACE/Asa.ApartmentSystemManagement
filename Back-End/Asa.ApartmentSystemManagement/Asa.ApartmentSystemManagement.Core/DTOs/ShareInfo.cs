using System;
using System.Collections.Generic;
using System.Text;

namespace Asa.ApartmentSystemManagement.Core.BaseInfo.DTOs
{
    public class ShareInfo
    {
        public int Days { get; set; }
        public decimal Area { get; set; }
        public int PersonId { get; set; }
        public int UnitId { get; set; }
        public int BuildingId { get; set; }
        public int NumberOfPeopel { get; set; }
    }
}
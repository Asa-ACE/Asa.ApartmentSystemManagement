using System;
using System.Collections.Generic;
using System.Text;

namespace Asa.ApartmentSystemManagement.Core.BaseInfo.DTOs
{
    public class ChargeDTO
    {
        public int Id { get; set; }
        public int BuildingId { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
    }
}

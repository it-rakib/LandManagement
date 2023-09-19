using System;
using System.Collections.Generic;

namespace Land.Domain.Models
{
    public partial class OwnerWize
    {
        public string DistrictName { get; set; }
        public string UpozilaName { get; set; }
        public string MouzaName { get; set; }
        public string OwnerInfoName { get; set; }
        public int? DeedQty { get; set; }
        public decimal? TotalLand { get; set; }
    }
}

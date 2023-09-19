using System;
using System.Collections.Generic;

namespace Land.Domain.Models
{
    public partial class UpozilaWizeLand
    {
        public string DistrictName { get; set; }
        public string UpozilaName { get; set; }
        public int? DeedQty { get; set; }
        public decimal? TotalLand { get; set; }
    }
}

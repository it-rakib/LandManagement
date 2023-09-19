using System;
using System.Collections.Generic;

namespace Land.Domain.Models
{
    public partial class DistrictWizeLand
    {
        public string DistrictName { get; set; }
        public int? DeedQty { get; set; }
        public decimal? TotalLand { get; set; }
    }
}

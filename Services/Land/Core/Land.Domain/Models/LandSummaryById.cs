using System;
using System.Collections.Generic;

namespace Land.Domain.Models
{
    public partial class LandSummaryById
    {
        public string DivisionName { get; set; }
        public string DistrictName { get; set; }
        public string UpozilaName { get; set; }
        public string MouzaName { get; set; }
        public string OwnerInfoName { get; set; }
    }
}

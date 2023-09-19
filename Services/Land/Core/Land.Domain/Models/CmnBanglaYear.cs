using System;
using System.Collections.Generic;

namespace Land.Domain.Models
{
    public partial class CmnBanglaYear
    {
        public CmnBanglaYear()
        {
            LandDevelopmentTaxes = new HashSet<LandDevelopmentTax>();
        }

        public Guid BanglaYearId { get; set; }
        public string BanglaYearName { get; set; }

        public virtual ICollection<LandDevelopmentTax> LandDevelopmentTaxes { get; set; }
    }
}

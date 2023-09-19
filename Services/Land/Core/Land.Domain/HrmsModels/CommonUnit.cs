using System;
using System.Collections.Generic;

namespace Merchandising.Domain.HrmsModels
{
    public partial class CommonUnit
    {
        public int UnitId { get; set; }
        public int CompanyId { get; set; }
        public string UnitName { get; set; }
        public string UnitShortName { get; set; }
        public string UnitNameBan { get; set; }
        public string UnitAddress { get; set; }
        public bool? IsActive { get; set; }
        public string UserId { get; set; }
        public string TerminalId { get; set; }
        public int? UnitTypeId { get; set; }
        public DateTime? EntryDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? UpdateBy { get; set; }
    }
}

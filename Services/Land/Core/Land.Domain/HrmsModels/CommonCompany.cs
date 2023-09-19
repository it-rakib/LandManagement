using System;
using System.Collections.Generic;

namespace Merchandising.Domain.HrmsModels
{
    public partial class CommonCompany
    {
        public int CompanyId { get; set; }
        public int? RootCompany { get; set; }
        public string CompanyName { get; set; }
        public string CompanyNameBan { get; set; }
        public string CompanyShortName { get; set; }
        public string CompanyAddress { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? EntryDate { get; set; }
        public int? EntryUserId { get; set; }
        public string TerminalId { get; set; }
        public int? ZoneId { get; set; }
    }
}

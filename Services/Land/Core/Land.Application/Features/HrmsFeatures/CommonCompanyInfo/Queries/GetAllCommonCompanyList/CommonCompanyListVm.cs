using System;

namespace Merchandising.Application.Features.HrmsFeatures.CommonCompanyInfo.Queries.GetAllCommonCompanyList
{
    public class CommonCompanyListVm
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
    }
}

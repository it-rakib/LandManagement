using System;

namespace Land.Application.Features.LandMasterInfo.Queries.GetAllDeedNoList
{
    public class AllDeedNoListVm
    {
        public Guid LandMasterId { get; set; }
        public string DeedNo { get; set; }
        public DateTime? EntryDate { get; set; }
        public Guid SubRegOfficeId { get; set; }
        public string SubRegOfficeName { get; set; }
        public decimal TotalLandAmount { get; set; }
    }
}

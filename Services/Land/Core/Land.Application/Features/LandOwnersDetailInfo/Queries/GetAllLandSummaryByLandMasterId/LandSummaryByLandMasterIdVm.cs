using System;

namespace Land.Application.Features.LandOwnersDetailInfo.Queries.GetAllLandSummaryByLandMasterId
{
    public class LandSummaryByLandMasterIdVm
    {
        public Guid OwnerInfoId { get; set; }
        public string OwnerInfoName { get; set; }
        public string DeedNo { get; set; }
        public Guid DistrictId { get; set; }
        public string DistrictName { get; set; }
        public Guid UpozilaId { get; set; }
        public string UpozilaName { get; set; }
        public Guid MouzaId { get; set; }
        public string MouzaName { get; set; }
        public decimal? LandAmount { get; set; }
        public DateTime? EntryDate { get; set; }
        //public string EntryDate { get; set; }
    }
}

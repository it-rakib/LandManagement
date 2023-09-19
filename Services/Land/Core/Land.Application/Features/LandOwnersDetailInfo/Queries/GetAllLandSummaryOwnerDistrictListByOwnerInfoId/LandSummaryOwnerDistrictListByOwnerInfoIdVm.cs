using System;

namespace Land.Application.Features.LandOwnersDetailInfo.Queries.GetAllLandSummaryOwnerDistrictListByOwnerInfoId
{
    public class LandSummaryOwnerDistrictListByOwnerInfoIdVm
    {
        public Guid OwnerInfoId { get; set; }
        public string OwnerInfoName { get; set; }
        public Guid DistrictId { get; set; }
        public string DistrictName { get; set; }
        public string DeedNo { get; set; }
        public int DeedQty { get; set; }
        public decimal? TotalLand { get; set; }
        public decimal? TotalLandAcres { get; set; }
    }
}

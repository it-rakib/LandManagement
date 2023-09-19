using System;

namespace Land.Application.Features.LandOwnersDetailInfo.Queries.GetAllLandSummaryPersonGrid
{
    public class GetAllLandSummaryPersonGridVm
    {
        public Guid OwnerInfoId { get; set; }
        public string OwnerInfoName { get; set; }
        public string DeedNo { get; set; }
        public int DeedQty { get; set; }
        public decimal? TotalLand { get; set; }
        public decimal? TotalLandAcres { get; set; }
    }
}

using System;

namespace Land.Application.Features.LandOwnersDetailInfo.Queries.GetAllLandOwnerGrid
{
    public class LandOwnerGridVm
    {
        public Guid OwnerInfoId { get; set; }
        public string OwnerInfoName { get; set; }
        public string DeedNo { get; set; }
        public int DeedQty { get; set; }
        public decimal? TotalLand { get; set; }
        public decimal? TotalLandAcres { get; set; }
    }
}

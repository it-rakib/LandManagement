using System;

namespace Land.Application.Features.LandMasterInfo.Queries.GetAllLandSummaryDistrictGrid
{
    public class GetAllLandSummaryDistrictGridVm
    {
        public Guid DistrictId { get; set; }
        public string DistrictName { get; set; }
        public Guid UpozilaId { get; set; }
        public string UpozilaName { get; set; }
        public int DeedQty { get; set; }
        public decimal TotalLandAcres { get; set; }
        public decimal? OwnerMutatedLandAmount { get; set; }
    }
}

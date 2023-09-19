using System;

namespace Land.Application.Features.LandMasterInfo.Queries.GetAllLandSummaryDistrictByDistrictId
{
    public class LandSummaryDistrictByDistrictIdVm
    {
        public Guid DistrictId { get; set; }
        public string DistrictName { get; set; }
        public int DeedQty { get; set; }
        public decimal TotalLandAcres { get; set; }
    }
}

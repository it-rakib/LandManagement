using System;

namespace Land.Application.Features.LandMasterInfo.Queries.GetAllLandSummaryByDistrictId
{
    public class GetLandSummaryByDistrictIdVm
    {
        public Guid DivisionId { get; set; }
        public string DivisionName { get; set; }
        public Guid DistrictId { get; set; }
        public string DistrictName { get; set; }
        public Guid UpozilaId { get; set; }
        public string UpozilaName { get; set; }
        public int DeedQty { get; set; }
        public decimal TotalLandAcres { get; set; }

    }
}

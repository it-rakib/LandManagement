using System;

namespace Land.Application.Features.LandMasterInfo.Queries.GetAllLandSummaryByDivisionId
{
    public class GetAllLandSummaryByDivisionIdVm
    {
        public Guid DivisionId { get; set; }
        public string DivisionName { get; set; }
        public Guid DistrictId { get; set; }
        public string DistrictName { get; set; }
        public int DeedQty { get; set; }
        public decimal TotalLandAmount { get; set; }
    }
}

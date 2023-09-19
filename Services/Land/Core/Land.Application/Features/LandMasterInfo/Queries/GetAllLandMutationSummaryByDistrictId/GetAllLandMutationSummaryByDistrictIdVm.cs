using System;

namespace Land.Application.Features.LandMasterInfo.Queries.GetAllLandMutationSummaryByDistrictId
{
    public class GetAllLandMutationSummaryByDistrictIdVm
    {
        public Guid DivisionId { get; set; }
        public string DivisionName { get; set; }
        public Guid DistrictId { get; set; }
        public string DistrictName { get; set; }
        public Guid UpozilaId { get; set; }
        public string UpozilaName { get; set; }
        public int DeedQty { get; set; }
        public decimal TotalLandAmount { get; set; }
        public decimal OwnerMutatedLandAmount { get; set; }
    }
}

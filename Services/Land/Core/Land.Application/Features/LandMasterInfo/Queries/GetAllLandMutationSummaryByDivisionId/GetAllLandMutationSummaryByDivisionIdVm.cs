using System;

namespace Land.Application.Features.LandMasterInfo.Queries.GetAllLandMutationSummaryByDivisionId
{
    public class GetAllLandMutationSummaryByDivisionIdVm
    {
        //public Guid MutationMasterId { get; set; }
        //public Guid DivisionId { get; set; }
        public string DivisionName { get; set; }
        //public Guid DistrictId { get; set; }
        public string DistrictName { get; set; }
        public decimal? OwnerLandAmount { get; set; }
        public decimal? OwnerMutatedLandAmount { get; set; }
        public decimal? TotalLandAmount { get; set; }
        public decimal? TotalLandAcres { get; set; }
        public int DeedQty { get; set; }
    }
}

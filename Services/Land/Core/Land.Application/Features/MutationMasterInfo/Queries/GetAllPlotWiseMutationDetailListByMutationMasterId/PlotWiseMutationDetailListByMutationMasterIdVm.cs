using System;

namespace Land.Application.Features.MutationMasterInfo.Queries.GetAllPlotWiseMutationDetailListByMutationMasterId
{
    public class PlotWiseMutationDetailListByMutationMasterIdVm
    {
        public Guid PlotWiseMutationDetailId { get; set; }
        public Guid MutationMasterId { get; set; }
        public Guid LandMasterId { get; set; }
        public string DeedNo { get; set; }
        public Guid KhatianTypeId { get; set; }
        public string KhatianTypeName { get; set; }
        public string? KhatianNo { get; set; }
        public string? DagNo { get; set; }
        public decimal? PlotWiseMutationLandAmount { get; set; }
    }
}

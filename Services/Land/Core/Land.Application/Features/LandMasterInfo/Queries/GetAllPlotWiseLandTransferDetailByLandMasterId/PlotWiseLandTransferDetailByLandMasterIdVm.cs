using System;

namespace Land.Application.Features.LandMasterInfo.Queries.GetAllPlotWiseLandTransferDetailByLandMasterId
{
    public class PlotWiseLandTransferDetailByLandMasterIdVm
    {
        public Guid PlotWiseLandTransferDetailId { get; set; }
        public Guid LandMasterId { get; set; }
        public Guid TransferedLandMasterId { get; set; }
        public string TransferedDeedNo { get; set; }
        public Guid TransferedKhatianTypeId { get; set; }
        public string TransferedKhatianTypeName { get; set; }
        public int TransferedDagNo { get; set; }
        public decimal PlotWiseTransferedLandAmount { get; set; }
    }
}

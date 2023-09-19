using System;

namespace Land.Application.Features.LandMasterInfo.Queries.GetAllPlotWiseLandSaleDetailByLandMasterId
{
    public class PlotWiseLandSaleDetailByLandMasterIdVm
    {
        public Guid PlotWiseLandSaleDetailId { get; set; }
        public Guid LandMasterId { get; set; }
        public Guid SaleLandMasterId { get; set; }
        public string SaleDeedNo { get; set; }
        public Guid SaleKhatianTypeId { get; set; }
        public string SaleKhatianTypeName { get; set; }
        public int SaleDagNo { get; set; }
        public decimal PlotWiseSaleLandAmount { get; set; }
    }
}

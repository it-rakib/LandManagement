using System;

namespace Land.Application.Features.LandMasterInfo.Queries.GetAllLandSummaryUpozilaGrid
{
    public class LandSummaryUpozilaGridVm
    {
        public Guid DistrictId { get; set; }
        public string DistrictName { get; set; }
        public Guid UpozilaId { get; set; }
        public string UpozilaName { get; set; }
        public Guid MouzaId { get; set; }
        public string MouzaName { get; set; }
        public int DeedQty { get; set; }
        public decimal TotalLandAcres { get; set; }
    }
}

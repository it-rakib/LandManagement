using System;

namespace Land.Application.Features.LandMasterInfo.Queries.GetAllLandSummaryOwnerMouzaCommonGrid
{
    public class GetAllLandSummaryOwnerMouzaCommonGridVm
    {
        public Guid DistrictId { get; set; }
        public string DistrictName { get; set; }
        public Guid UpozilaId { get; set; }
        public string UpozilaName { get; set; }
        public Guid MouzaId { get; set; }
        public string MouzaName { get; set; }
        public Guid OwnerInfoId { get; set; }
        public string OwnerInfoName { get; set; }
        public int DeedQty { get; set; }
        public decimal? TotalLand { get; set; }
    }
}

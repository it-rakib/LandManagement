using System;

namespace Land.Application.Features.LandMasterInfo.Queries.GetAllLandSummaryFileDeedOwnerCommonGrid
{
    public class GetAllLandSummaryFileDeedOwnerCommonGridVm
    {

        public Guid FileCodeInfoId { get; set; }
        public string FileCodeInfoName { get; set; }
        public Guid FileNoInfoId { get; set; }
        public int FileNoInfoName { get; set; }
        public Guid DistrictId { get; set; }
        public string DistrictName { get; set; }
        public Guid UpozilaId { get; set; }
        public string UpozilaName { get; set; }
        public Guid MouzaId { get; set; }
        public string MouzaName { get; set; }
        public Guid OwnerInfoId { get; set; }
        public string OwnerInfoName { get; set; }
        public string DeedNo { get; set; }
        public decimal? LandAmount { get; set; }
    }
}

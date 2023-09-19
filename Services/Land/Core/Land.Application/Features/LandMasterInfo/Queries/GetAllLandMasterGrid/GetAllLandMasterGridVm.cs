using Land.Application.Features.CmnDocument;
using System;
using System.Collections.Generic;

namespace Land.Application.Features.LandMasterInfo.Queries.GetAllLandMasterGrid
{
    public class GetAllLandMasterGridVm
    {
        public Guid LandMasterId { get; set; }
        public string FileNo { get; set; }
        public Guid DivisionId { get; set; }
        public string DivisionName { get; set; }
        public Guid DistrictId { get; set; }
        public string DistrictName { get; set; }
        public Guid UpozilaId { get; set; }
        public string UpozilaName { get; set; }
        public Guid MouzaId { get; set; }
        public string MouzaName { get; set; }
        public Guid OwnerInfoId { get; set; }
        public string OwnerInfoName { get; set; }
        public DateTime? EntryDate { get; set; }
        public string DeedNo { get; set; }
        public Guid SubRegOfficeId { get; set; }
        public string SubRegOfficeName { get; set; }
        public bool? IsTransfered { get; set; }
        public bool? IsSale{ get; set; }
        public string SaleStatus { get; set; }
        public bool? IsBayna { get; set; }
        public string BaynaStatus { get; set; }
        public string TransferedStatus { get; set; }
        public decimal? TotalLandAmount { get; set; }
        public decimal? LandRegAmount { get; set; }
        public decimal? LandPurchaseAmount { get; set; }
        public decimal? LandDevelopmentAmount { get; set; }
        public decimal? LandOtherAmount { get; set; }
        public string Remarks { get; set; }
        public string FileRemarks { get; set; }
        public DateTime? CreatedAt { get; set; }
        public bool? IsDeleted { get; set; }

        public List<FilesVm> FilesVm { get; set; }
    }
}

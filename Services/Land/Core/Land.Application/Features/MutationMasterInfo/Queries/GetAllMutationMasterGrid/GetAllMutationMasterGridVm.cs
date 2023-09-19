using Land.Application.Features.CmnDocument;
using System;
using System.Collections.Generic;

namespace Land.Application.Features.MutationMasterInfo.Queries.GetAllMutationMasterGrid
{
    public class GetAllMutationMasterGridVm
    {
        public Guid LandMasterId { get; set; }
        public Guid MutationMasterId { get; set; }
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
        public decimal? OwnerMutatedLandAmount { get; set; }
        public decimal? OwnerLandAmount { get; set; }
        public string MutationApplicationNo { get; set; }
        public DateTime? MutationApplicationDate { get; set; }
        public string CaseNo { get; set; }
        public string Dcrno { get; set; }
        public string MutationKhatianNo { get; set; }
        public string HoldingNo { get; set; }
        public string DeedNo { get; set; }
        public string Remarks { get; set; }
        public bool? IsRecorded { get; set; }
        public bool? IsDeleted { get; set; }
        public string FileRemarks { get; set; }

        public DateTime? CreatedAt { get; set; }
        public List<FilesVm> FilesVm { get; set; }
    }
}

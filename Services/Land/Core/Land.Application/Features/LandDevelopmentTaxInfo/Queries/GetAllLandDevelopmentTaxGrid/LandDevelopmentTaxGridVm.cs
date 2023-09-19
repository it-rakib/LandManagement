using Land.Application.Features.CmnDocument;
using System;
using System.Collections.Generic;

namespace Land.Application.Features.LandDevelopmentTaxInfo.Queries.GetAllLandDevelopmentTaxGrid
{
    public class LandDevelopmentTaxGridVm
    {
        public Guid LandDevelopmentTaxId { get; set; }
        public Guid MutationMasterId { get; set; }
        public string DakhilaNo { get; set; }
        public string HoldingNo { get; set; }
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
        public Guid FromDate { get; set; }
        public string FromDateName { get; set; }
        public Guid ToDate { get; set; }
        public string ToDateName { get; set; }
        public decimal? TaxAmount { get; set; }
        public decimal? OwnerMutatedLandAmount { get; set; }
        public string Remarks { get; set; }
        public string FileRemarks { get; set; }
        public DateTime? CreatedAt { get; set; }
        public bool? IsDeleted { get; set; }
        public List<FilesVm> FilesVm { get; set; }
    }
}

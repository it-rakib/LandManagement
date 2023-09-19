using Land.Application.Features.CmnDocument;
using System;
using System.Collections.Generic;

namespace Land.Application.Features.LandMapInfo.Queries.GetAllMapInfoGrid
{
    public class GetAllMapInfoGridVm
    {
        public Guid LandMapId { get; set; }
        public Guid DivisionId { get; set; }
        public string DivisionName { get; set; }
        public Guid DistrictId { get; set; }
        public string DistrictName { get; set; }
        public Guid UpozilaId { get; set; }
        public string UpozilaName { get; set; }
        public Guid MouzaId { get; set; }
        public string MouzaName { get; set; }
        public int? MapTypeId { get; set; }
        public string MapTypeName { get; set; }
        public Guid SheetNoInfoId { get; set; }
        public int SheetNo { get; set; }
        //public Guid KhatianTypeId { get; set; }
        //public string KhatianTypeName { get; set; }
        public string Remarks { get; set; }
        public string FileRemarks { get; set; }
        public bool? IsDeleted { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string CreatedPcIp { get; set; }
        public long? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public long? DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
        public List<FilesVm> FilesVm { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace Land.Domain.Models
{
    public partial class LandMap
    {
        public Guid LandMapId { get; set; }
        public Guid DivisionId { get; set; }
        public Guid DistrictId { get; set; }
        public Guid UpozilaId { get; set; }
        public Guid MouzaId { get; set; }
        public Guid SheetNoInfoId { get; set; }
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
        public int? MapTypeId { get; set; }

        public virtual CmnDistrict District { get; set; }
        public virtual CmnDivision Division { get; set; }
        public virtual MapType MapType { get; set; }
        public virtual CmnMouza Mouza { get; set; }
        public virtual SheetNoInfo SheetNoInfo { get; set; }
        public virtual CmnUpozila Upozila { get; set; }
    }
}

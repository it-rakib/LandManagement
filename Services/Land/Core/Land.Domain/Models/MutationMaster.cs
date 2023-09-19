using System;
using System.Collections.Generic;

namespace Land.Domain.Models
{
    public partial class MutationMaster
    {
        public MutationMaster()
        {
            LandDevelopmentTaxes = new HashSet<LandDevelopmentTax>();
            OwnerWiseMutationDetails = new HashSet<OwnerWiseMutationDetail>();
            PlotWiseMutationDetails = new HashSet<PlotWiseMutationDetail>();
        }

        public Guid MutationMasterId { get; set; }
        public Guid DivisionId { get; set; }
        public Guid DistrictId { get; set; }
        public Guid UpozilaId { get; set; }
        public Guid MouzaId { get; set; }
        public string MutationApplicationNo { get; set; }
        public DateTime? MutationApplicationDate { get; set; }
        public string CaseNo { get; set; }
        public string Dcrno { get; set; }
        public string MutationKhatianNo { get; set; }
        public string HoldingNo { get; set; }
        public string Remarks { get; set; }
        public string FileRemarks { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string CreatedPcIp { get; set; }
        public long? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public long? DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
        public bool IsDeleted { get; set; }
        public bool? IsRecorded { get; set; }

        public virtual ICollection<LandDevelopmentTax> LandDevelopmentTaxes { get; set; }
        public virtual ICollection<OwnerWiseMutationDetail> OwnerWiseMutationDetails { get; set; }
        public virtual ICollection<PlotWiseMutationDetail> PlotWiseMutationDetails { get; set; }
    }
}

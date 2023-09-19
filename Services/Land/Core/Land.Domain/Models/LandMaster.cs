using System;
using System.Collections.Generic;

namespace Land.Domain.Models
{
    public partial class LandMaster
    {
        public LandMaster()
        {
            BayaDeedDetails = new HashSet<BayaDeedDetail>();
            FileLocationDetails = new HashSet<FileLocationDetail>();
            KhatianDetails = new HashSet<KhatianDetail>();
            LandMasterOwnerRelations = new HashSet<LandMasterOwnerRelation>();
            LandOwnersDetails = new HashSet<LandOwnersDetail>();
            LandSalersInfos = new HashSet<LandSalersInfo>();
            OwnerWiseLandSaleDetails = new HashSet<OwnerWiseLandSaleDetail>();
            OwnerWiseLandTransferDetails = new HashSet<OwnerWiseLandTransferDetail>();
            OwnerWiseMutationDetails = new HashSet<OwnerWiseMutationDetail>();
            PlotWiseLandSaleDetails = new HashSet<PlotWiseLandSaleDetail>();
            PlotWiseLandTransferDetails = new HashSet<PlotWiseLandTransferDetail>();
            PlotWiseMutationDetails = new HashSet<PlotWiseMutationDetail>();
        }

        public Guid LandMasterId { get; set; }
        public Guid DivisionId { get; set; }
        public Guid DistrictId { get; set; }
        public Guid UpozilaId { get; set; }
        public string DeedNo { get; set; }
        public DateTime? EntryDate { get; set; }
        public Guid SubRegOfficeId { get; set; }
        public bool? IsTransfered { get; set; }
        public bool? IsSale { get; set; }
        public bool? IsBayna { get; set; }
        public decimal TotalLandAmount { get; set; }
        public decimal? LandRegAmount { get; set; }
        public decimal LandPurchaseAmount { get; set; }
        public decimal? LandDevelopmentAmount { get; set; }
        public decimal? LandOtherAmount { get; set; }
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

        public virtual CmnDistrict District { get; set; }
        public virtual CmnDivision Division { get; set; }
        public virtual CmnSubRegOffice SubRegOffice { get; set; }
        public virtual CmnUpozila Upozila { get; set; }
        public virtual ICollection<BayaDeedDetail> BayaDeedDetails { get; set; }
        public virtual ICollection<FileLocationDetail> FileLocationDetails { get; set; }
        public virtual ICollection<KhatianDetail> KhatianDetails { get; set; }
        public virtual ICollection<LandMasterOwnerRelation> LandMasterOwnerRelations { get; set; }
        public virtual ICollection<LandOwnersDetail> LandOwnersDetails { get; set; }
        public virtual ICollection<LandSalersInfo> LandSalersInfos { get; set; }
        public virtual ICollection<OwnerWiseLandSaleDetail> OwnerWiseLandSaleDetails { get; set; }
        public virtual ICollection<OwnerWiseLandTransferDetail> OwnerWiseLandTransferDetails { get; set; }
        public virtual ICollection<OwnerWiseMutationDetail> OwnerWiseMutationDetails { get; set; }
        public virtual ICollection<PlotWiseLandSaleDetail> PlotWiseLandSaleDetails { get; set; }
        public virtual ICollection<PlotWiseLandTransferDetail> PlotWiseLandTransferDetails { get; set; }
        public virtual ICollection<PlotWiseMutationDetail> PlotWiseMutationDetails { get; set; }
    }
}

using Land.Application.Features.CmnDocument;
using MediatR;
using System;
using System.Collections.Generic;

namespace Land.Application.Features.LandMasterInfo.Commands.CreateOrUpdateLandMaster
{
    public class CreateOrUpdateLandMasterCommand : IRequest<CreateOrUpdateLandMasterCommandResponse>
    {
        public Guid LandMasterId { get; set; }
        public Guid DivisionId { get; set; }
        public Guid DistrictId { get; set; }
        public Guid UpozilaId { get; set; }
        public string DeedNo { get; set; }
        public string EntryDate { get; set; }
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
        //public bool? IsDeleted { get; set; }

        public virtual ICollection<PlotWiseLandSaleCommand> PlotWiseLandSaleDetails { get; set; }
        public virtual ICollection<OwnerWiseLandSaleCommand> OwnerWiseLandSaleDetails { get; set; }
        public virtual ICollection<PlotWiseLandTransferDetailCommand> PlotWiseLandTransferDetails { get; set; }
        public virtual ICollection<OwnerWiseLandTransferDetailCommand> OwnerWiseLandTransferDetails { get; set; }
        public virtual ICollection<LandMasterOwnerRelationCommand> LandMasterOwnerRelations { get; set; }
        public virtual ICollection<LandSalersInfoCommand> LandSalersInfos { get; set; }
        public virtual ICollection<KhatianDetailCommand> KhatianDetails { get; set; }
        public virtual ICollection<LandOwnersDetailCommand> LandOwnersDetails { get; set; }
        public virtual ICollection<DocumentVM> DocumentVms { get; set; }
        //Baya Deed
        public virtual ICollection<BayaDeedDetailCommand> BayaDeedDetails { get; set; }
    }

    public class PlotWiseLandSaleCommand
    {
        public Guid PlotWiseLandSaleDetailId { get; set; }
        public Guid LandMasterId { get; set; }
        public Guid SaleLandMasterId { get; set; }
        public Guid SaleKhatianTypeId { get; set; }
        public int SaleDagNo { get; set; }
        public decimal PlotWiseSaleLandAmount { get; set; }
    }
    public class OwnerWiseLandSaleCommand
    {
        public Guid OwnerWiseLandSaleDetailId { get; set; }
        public Guid LandMasterId { get; set; }
        public Guid SaleLandMasterId { get; set; }
        public Guid SaleKhatianTypeId { get; set; }
        public Guid SaleOwnerInfoId { get; set; }
        public decimal OwnerWiseSaleLandAmount { get; set; }
    }

    public class PlotWiseLandTransferDetailCommand
    {
        public Guid PlotWiseLandTransferDetailId { get; set; }
        public Guid LandMasterId { get; set; }
        public Guid TransferedLandMasterId { get; set; }
        public Guid TransferedKhatianTypeId { get; set; }
        public int TransferedDagNo { get; set; }
        public decimal PlotWiseTransferedLandAmount { get; set; }
    }
    public class OwnerWiseLandTransferDetailCommand
    {
        public Guid OwnerWiseLandTransferDetailId { get; set; }
        public Guid LandMasterId { get; set; }
        public Guid TransferedLandMasterId { get; set; }
        public Guid TransferedKhatianTypeId { get; set; }
        public Guid TransferedOwnerInfoId { get; set; }
        public decimal OwnerWiseTransferedLandAmount { get; set; }
    }
    public class LandMasterOwnerRelationCommand
    {
        public Guid LandMasterOwnerRelationId { get; set; }
        public Guid LandMasterId { get; set; }
        public Guid LandOwnerTypeId { get; set; }
        public string OtherRemarks { get; set; }
    }
    public class LandSalersInfoCommand
    {
        public Guid SalersInfoId { get; set; }
        public Guid LandMasterId { get; set; }
        public string SalerName { get; set; }
        public string SalerFatherName { get; set; }
        public string SalerAddress { get; set; }
    }
    public class KhatianDetailCommand
    {
        public Guid KhatianDetailId { get; set; }
        public Guid LandMasterId { get; set; }
        public Guid MouzaId { get; set; }
        public Guid KhatianTypeId { get; set; }
        //public int? KhatianNo { get; set; }
        public string? KhatianNo { get; set; }
        public string DagNo { get; set; }
        public string RecordedOwnerName { get; set; }
    }
    public class LandOwnersDetailCommand
    {
        public Guid LandOwnersDetailId { get; set; }
        public Guid LandMasterId { get; set; }
        public Guid OwnerInfoId { get; set; }
        public string SaleOwnerName { get; set; }
        public Guid MouzaId { get; set; }
        public decimal? LandAmount { get; set; }
        public decimal? OwnerRegAmount { get; set; }
        public decimal? OwnerPurchaseAmount { get; set; }
    }
    public class BayaDeedDetailCommand
    {
        public Guid BayaDeedDetailId { get; set; }
        public Guid LandMasterId { get; set; }
        public string BayaDeedNo { get; set; }
        public DateTime? BayaDeedDate { get; set; }
    }
}


using System;
using System.Collections.Generic;
using Land.Application.Features.CmnDocument;
using MediatR;

namespace Land.Application.Features.MutationMasterInfo.Commands.CreateOrUpdateMutationMaster
{
    public class CreateOrUpdateMutationMasterCommand : IRequest<CreateOrUpdateMutationMasterCommandResponse>
    {
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

        public virtual ICollection<PlotWiseMutationDetailCommand> PlotWiseMutationDetails { get; set; }
        public virtual ICollection<OwnerWiseMutationDetailCommand> OwnerWiseMutationDetails { get; set; }
        public virtual ICollection<DocumentVM> DocumentVms { get; set; }
    }

    public class PlotWiseMutationDetailCommand
    {
        public Guid PlotWiseMutationDetailId { get; set; }
        public Guid MutationMasterId { get; set; }
        public Guid LandMasterId { get; set; }
        public Guid KhatianTypeId { get; set; }
        public string? KhatianNo { get; set; }
        public string? DagNo { get; set; }
        public decimal PlotWiseMutationLandAmount { get; set; }
    }

    public class OwnerWiseMutationDetailCommand
    {
        public Guid OwnerWiseMutationDetailId { get; set; }
        public Guid MutationMasterId { get; set; }
        public Guid LandMasterId { get; set; }
        public Guid KhatianTypeId { get; set; }
        public Guid OwnerInfoId { get; set; }
        public decimal? OwnerLandAmount { get; set; }
        public decimal? OwnerMutatedLandAmount { get; set; }
    }
}

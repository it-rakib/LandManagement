using System;

namespace Land.Application.Features.MutationMasterInfo.Queries.GetAllOwnerWiseMutationDetailListByMutationMasterId
{
    public class OwnerWiseMutationDetailListByMutationMasterIdVm
    {
        public Guid OwnerWiseMutationDetailId { get; set; }
        public Guid MutationMasterId { get; set; }
        public Guid LandMasterId { get; set; }
        public Guid KhatianTypeId { get; set; }
        public string KhatianTypeName { get; set; }
        public string DeedNo { get; set; }
        public Guid OwnerInfoId { get; set; }
        public string OwnerInfoName { get; set; }
        public decimal? OwnerLandAmount { get; set; }
        public decimal? OwnerMutatedLandAmount { get; set; }
    }
}

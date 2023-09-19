using System;

namespace Land.Application.Features.LandMasterInfo.Queries.GetAllOwnerWiseLandTransferDetailByLandMasterId
{
    public class OwnerWiseLandTransferDetailByLandMasterIdVm
    {
        public Guid OwnerWiseLandTransferDetailId { get; set; }
        public Guid LandMasterId { get; set; }
        public Guid TransferedLandMasterId { get; set; }
        public string TransferedDeedNo { get; set; }
        public Guid TransferedKhatianTypeId { get; set; }
        public string TransferedKhatianTypeName { get; set; }
        public Guid TransferedOwnerInfoId { get; set; }
        public string TransferedOwnerInfoName { get; set; }
        public decimal OwnerWiseTransferedLandAmount { get; set; }
    }
}

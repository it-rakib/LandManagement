using System;

namespace Land.Application.Features.LandOwnersDetailInfo.Queries.GetAllLandOwnerDetailByLandMasterIdMouzaId
{
    public class LandOwnerDetailByLandMasterIdMouzaIdVm
    {
        public Guid LandOwnersDetailId { get; set; }
        public Guid LandMasterId { get; set; }
        public Guid MouzaId { get; set; }
        public string MouzaName { get; set; }
        public Guid OwnerInfoId { get; set; }
        public string OwnerInfoName { get; set; }
        public decimal? LandAmount { get; set; }
    }
}

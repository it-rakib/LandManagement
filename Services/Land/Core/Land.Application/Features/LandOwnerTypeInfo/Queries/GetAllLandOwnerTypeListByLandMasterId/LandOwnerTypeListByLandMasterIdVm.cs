using System;

namespace Land.Application.Features.LandOwnerTypeInfo.Queries.GetAllLandOwnerTypeListByLandMasterId
{
    public class LandOwnerTypeListByLandMasterIdVm
    {
        public Guid LandMasterId { get; set; }
        public Guid LandOwnerTypeId { get; set; }
        public string LandOwnerTypeName { get; set; }
        public string OtherRemarks { get; set; }
        public Guid LandMasterOwnerRelationId { get; set; }
    }
}

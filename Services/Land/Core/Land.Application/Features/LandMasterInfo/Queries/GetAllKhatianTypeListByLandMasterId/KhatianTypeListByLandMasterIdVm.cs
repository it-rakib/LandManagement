using System;

namespace Land.Application.Features.LandMasterInfo.Queries.GetAllKhatianTypeListByLandMasterId
{
    public class KhatianTypeListByLandMasterIdVm
    {
        public Guid LandMasterId { get; set; }
        public Guid KhatianTypeId { get; set; }
        public string KhatianTypeName { get; set; }
    }
}

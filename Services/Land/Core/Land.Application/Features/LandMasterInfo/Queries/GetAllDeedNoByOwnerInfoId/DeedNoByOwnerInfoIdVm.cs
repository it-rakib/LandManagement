using System;

namespace Land.Application.Features.LandMasterInfo.Queries.GetAllDeedNoByOwnerInfoId
{
    public class DeedNoByOwnerInfoIdVm
    {
        public Guid LandMasterId { get; set; }
        public string DeedNo { get; set; }
    }
}

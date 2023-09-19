using System;

namespace Land.Application.Features.MutationMasterInfo.Queries.GetAllMutatedDeedNoList
{
    public class MutatedDeedNoListVm
    {
        public Guid LandMasterId { get; set; }
        public string DeedNo { get; set; }
        public string Status { get; set; }
    }
}

using System;

namespace Land.Application.Features.LandMasterInfo.Queries.GetAllBayaDeedDetailListByLandMasterId
{
    public class BayaDeedDetailListByLandMasterIdVm
    {
        public Guid BayaDeedDetailId { get; set; }
        public Guid LandMasterId { get; set; }
        public string BayaDeedNo { get; set; }
        public DateTime? BayaDeedDate { get; set; }
    }
}

using System;

namespace Land.Application.Features.FileLocation.Queries.GetAllFileLocationDetailListByFileLocationMasterId
{
    public class FileLocationDetailListByFileLocationMasterIdVm
    {
        public Guid FileLocationDetailId { get; set; }
        public Guid FileLocationMasterId { get; set; }
        public Guid LandMasterId { get; set; }
        public string DeedNo { get; set; }
    }
}

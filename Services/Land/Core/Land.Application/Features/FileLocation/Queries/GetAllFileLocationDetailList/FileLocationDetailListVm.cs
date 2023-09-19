using System;

namespace Land.Application.Features.FileLocation.Queries.GetAllFileLocationDetailList
{
    public class FileLocationDetailListVm 
    {
        public Guid FileLocationDetailId { get; set; }
        public Guid FileLocationMasterId { get; set; }
        public Guid LandMasterId { get; set; }
        public string DeedNo { get; set; }
    }
}

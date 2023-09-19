using System;

namespace Land.Application.Features.FileLocation.Queries.GetAllFileLocationGrid
{
    public class FileLocationGridVm
    {
        public Guid FileLocationMasterId { get; set; }
        public Guid FileCodeInfoId { get; set; }
        public string FileCodeInfoName { get; set; }
        public Guid FileNoInfoId { get; set; }
        public int FileNoInfoName { get; set; }
        public Guid AlmirahNoInfoId { get; set; }
        public int AlmirahNoInfoName { get; set; }
        public Guid RackNoInfoId { get; set; }
        public int RackNoInfoName { get; set; }
        public string Remarks { get; set; }
        public string DeedNo { get; set; }
        public bool? IsDeleted { get; set; }
        //public DateTime CreatedAt { get; set; }
    }
}

using System;

namespace Land.Application.Features.FileCode.Queries.GetAllFileCodeGrid
{
    public class GetAllFileCodeGridVm
    {
        public Guid FileCodeInfoId { get; set; }
        public string FileCodeInfoName { get; set; }
        public string FileCodeInfoFullName { get; set; }
        public bool? IsActive { get; set; }
    }
}

using System;

namespace Land.Application.Features.FileCode.Queries.GetAllFileCodeList
{
    public class FileCodeListVm
    {
        public Guid FileCodeInfoId { get; set; }
        public string FileCodeInfoName { get; set; }
        public string FileCodeInfoFullName { get; set; }
    }
}

using System;

namespace Land.Application.Features.FileNo.Queries.GetFileNoListByFileCodeId
{
    public class FileNoListByFileCodeIdVm
    {
        public Guid FileNoInfoId { get; set; }
        public int? FileNoInfoName { get; set; }
        public Guid FileCodeInfoId { get; set; }
        public string FileCodeInfoName { get; set; }
    }
}

using System;

namespace Land.Application.Features.FileCode.Commands.CreateUpdateFileCode
{
    public class CreateUpdateFileCodeDTO
    {
        public Guid FileCodeInfoId { get; set; }
        public string FileCodeInfoName { get; set; }
        //public string FileCodeInfoFullName { get; set; }
    }
}

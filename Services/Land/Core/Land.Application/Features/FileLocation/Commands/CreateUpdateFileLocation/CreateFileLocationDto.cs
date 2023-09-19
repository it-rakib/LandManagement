using System;

namespace Land.Application.Features.FileLocation.Commands.CreateUpdateFileLocation
{
    public class CreateFileLocationDto
    {
        public Guid FileLocationMasterId { get; set; }
        public Guid? FileNoInfoId { get; set; }
        public int FileNoInfoName { get; set; }
        public Guid RackNoInfoId { get; set; }
        public int RackNoInfoName { get; set; }
    }
}

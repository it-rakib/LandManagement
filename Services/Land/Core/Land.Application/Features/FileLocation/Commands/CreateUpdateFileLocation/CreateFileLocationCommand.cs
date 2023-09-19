using MediatR;
using System;
using System.Collections.Generic;

namespace Land.Application.Features.FileLocation.Commands.CreateUpdateFileLocation
{
    public class CreateFileLocationCommand : IRequest<CreateFileLocationCommandResponse>
    {
        public Guid FileLocationMasterId { get; set; }
        public Guid FileCodeInfoId { get; set; }
        public Guid FileNoInfoId { get; set; }
        public Guid AlmirahNoInfoId { get; set; }
        public Guid RackNoInfoId { get; set; }
        public string Remarks { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string CreatedPcIp { get; set; }
        public long? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public long? DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
        public bool IsDeleted { get; set; }
        public virtual ICollection<FileLocationDetailCommand> FileLocationDetails { get; set; }

    }

    public class FileLocationDetailCommand
    {
        public Guid FileLocationDetailId { get; set; }
        public Guid FileLocationMasterId { get; set; }
        public Guid LandMasterId { get; set; }
    }
}

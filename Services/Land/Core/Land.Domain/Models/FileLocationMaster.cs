using System;
using System.Collections.Generic;

namespace Land.Domain.Models
{
    public partial class FileLocationMaster
    {
        public FileLocationMaster()
        {
            FileLocationDetails = new HashSet<FileLocationDetail>();
        }

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

        public virtual FileNoInfo FileNoInfo { get; set; }
        public virtual RackNoInfo RackNoInfo { get; set; }
        public virtual ICollection<FileLocationDetail> FileLocationDetails { get; set; }
    }
}

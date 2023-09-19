using System;
using System.Collections.Generic;

namespace Land.Domain.Models
{
    public partial class FileCodeInfo
    {
        public FileCodeInfo()
        {
            FileNoInfos = new HashSet<FileNoInfo>();
        }

        public Guid FileCodeInfoId { get; set; }
        public string FileCodeInfoName { get; set; }
        public string FileCodeInfoFullName { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<FileNoInfo> FileNoInfos { get; set; }
    }
}

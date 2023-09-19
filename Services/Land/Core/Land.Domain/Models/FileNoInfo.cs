using System;
using System.Collections.Generic;

namespace Land.Domain.Models
{
    public partial class FileNoInfo
    {
        public FileNoInfo()
        {
            FileLocationMasters = new HashSet<FileLocationMaster>();
        }

        public Guid FileNoInfoId { get; set; }
        public Guid FileCodeInfoId { get; set; }
        public int FileNoInfoName { get; set; }

        public virtual FileCodeInfo FileCodeInfo { get; set; }
        public virtual ICollection<FileLocationMaster> FileLocationMasters { get; set; }
    }
}

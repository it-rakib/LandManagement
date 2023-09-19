using System;
using System.Collections.Generic;

namespace Land.Domain.Models
{
    public partial class CmnDocumentFile
    {
        public Guid DocumentId { get; set; }
        public string FileName { get; set; }
        public string ModuleName { get; set; }
        public Guid ModuleMasterId { get; set; }
        public int? FileSize { get; set; }
        public string FileExtension { get; set; }
        public string FileUniqueName { get; set; }
    }
}

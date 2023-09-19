using System;

namespace Land.Application.Features.CmnDocument
{
    public class DocumentVM
    {
        public Guid DocumentId { get; set; }
        public string FileName { get; set; }
        public string ModuleName { get; set; }
        public Guid ModuleMasterId { get; set; }
        public int? FileSize { get; set; }
        public string FileExtension { get; set; }
        public string FileUniqueName { get; set; }
        public string ActionType { get; set; }

    }

    public class FilesVm
    {
        public Guid docId { get; set; }
        public string name { get; set; }
        public int size { get; set; }
        public string extension { get; set; }
        public string fileUniq { get; set; }
    }
}

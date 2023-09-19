using System;

namespace Land.Application.Features.LandOwnerInfo.Queries.GetAllOwnerGrid
{
    public class OwnerInfoGridVm
    {
        public Guid OwnerInfoId { get; set; }
        public string OwnerInfoName { get; set; }
        public bool IsCompany { get; set; }
        public bool? IsActive { get; set; }
        public string Status { get; set; }
    }
}

using System;

namespace Land.Application.Features.LandOwnerTypeInfo.Queries.GetAllLandOwnerTypeList
{
    public class GetAllLandOwnerTypeListVm
    {
        public Guid LandOwnerTypeId { get; set; }
        public string LandOwnerTypeName { get; set; }
        public int? OrderBy { get; set; }
    }
}

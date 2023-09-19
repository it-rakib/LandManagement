using System;

namespace Land.Application.Features.LandMasterInfo.Queries.GetAllUpozilaByDistrictIdList
{
    public class GetAllUpozilaByDistrictIdListVm
    {
        public Guid UpozilaId { get; set; }
        public string UpozilaName { get; set; }
        public int DeedQty { get; set; }
        public decimal TotalLandAcres { get; set; }
    }
}

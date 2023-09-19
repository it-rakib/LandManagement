using System;

namespace Land.Application.Features.CmnUpozilaInfo.Queries.GetAllCmnUpozilaByDistrictId
{
    public class CmnUpozilaByDistrictIdVM
    {
        public Guid UpozilaId { get; set; }
        public string UpozilaName { get; set; }
        public Guid DistrictId { get; set; }
        public string DistrictName { get; set; }
    }
}

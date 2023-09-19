using System;

namespace Land.Application.Features.CmnUpozilaInfo.Queries.GetAllCmnUpozilaGrid
{
    public class CmnUpozilaGridVM
    {
        public Guid UpozilaId { get; set; }
        public string UpozilaName { get; set; }
        public Guid DistrictId { get; set; }
        public string DistrictName { get; set; }
        public Guid DivisionId { get; set; }
        public string DivisionName { get; set; }
    }
}

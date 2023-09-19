using System;

namespace Land.Application.Features.CmnDistrictInfo.Queries.GetAllCmnDistrictGrid
{
    public class CmnDistrictGridVM
    {
        public Guid DistrictId { get; set; }
        public string DistrictName { get; set; }
        public Guid DivisionId { get; set; }
        public string DivisionName { get; set; }
    }
}

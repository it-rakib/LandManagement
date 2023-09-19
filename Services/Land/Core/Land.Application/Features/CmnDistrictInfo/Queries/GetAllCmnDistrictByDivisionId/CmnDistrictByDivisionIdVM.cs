using System;

namespace Land.Application.Features.CmnDistrictInfo.Queries.GetAllCmnDistrictByDivisionId
{
    public class CmnDistrictByDivisionIdVM
    {
        public Guid DistrictId { get; set; }
        public string DistrictName { get; set; }
        public Guid DivisionId { get; set; }
        public string DivisionName { get; set; }
    }
}

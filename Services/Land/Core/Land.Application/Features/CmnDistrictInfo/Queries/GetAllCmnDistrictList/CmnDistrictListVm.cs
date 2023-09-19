using System;

namespace Land.Application.Features.CmnDistrictInfo.Queries.GetAllCmnDistrictList
{
    public class CmnDistrictListVm
    {
        public Guid DistrictId { get; set; }
        public string DistrictName { get; set; }
        public Guid DivisionId { get; set; }
    }
}

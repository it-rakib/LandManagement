using System;

namespace Land.Application.Features.CmnSubRegOfficeInfo.Queries.GetAllCmnSubRegOfficeGrid
{
    public class CmnSubRegOfficeGridVM
    {
        public Guid SubRegOfficeId { get; set; }
        public string SubRegOfficeName { get; set; }
        public Guid UpozilaId { get; set; }
        public string UpozilaName { get; set; }
        public Guid DistrictId { get; set; }
        public string DistrictName { get; set; }
        public Guid DivisionId { get; set; }
        public string DivisionName { get; set; }
        public bool? IsActive { get; set; }
    }
}

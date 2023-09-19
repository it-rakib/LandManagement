using System;

namespace Land.Application.Features.CmnSubRegOfficeInfo.Queries.GetAllCmnSubRegOfficeByUpozilaId
{
    public class CmnSubRegOfficeByUpozilaIdVM
    {
        public Guid SubRegOfficeId { get; set; }
        public string SubRegOfficeName { get; set; }
        public Guid UpozilaId { get; set; }
        public string UpozilaName { get; set; }
    }
}

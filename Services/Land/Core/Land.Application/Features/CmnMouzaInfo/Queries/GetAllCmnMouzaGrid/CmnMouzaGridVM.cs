using System;

namespace Land.Application.Features.CmnMouzaInfo.Queries.GetAllCmnMouzaGrid
{
    public class CmnMouzaGridVM
    {
        public Guid MouzaId { get; set; }
        public string MouzaName { get; set; }
        public Guid UpozilaId { get; set; }
        public string UpozilaName { get; set; }
        public Guid DistrictId { get; set; }
        public string DistrictName { get; set; }
        public Guid DivisionId { get; set; }
        public string DivisionName { get; set; }
    }
}

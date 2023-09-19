using System;

namespace Land.Application.Features.CmnMouzaInfo.Queries.GetAllCmnMouzaByUpozilaId
{
    public class CmnMouzaByUpozilaIdVM
    {
        public Guid MouzaId { get; set; }
        public string MouzaName { get; set; }
        public Guid UpozilaId { get; set; }
        public string UpozilaName { get; set; }
    }
}

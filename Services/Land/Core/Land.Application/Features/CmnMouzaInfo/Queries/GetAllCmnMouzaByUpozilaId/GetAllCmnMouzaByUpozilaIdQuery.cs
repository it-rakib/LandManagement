using MediatR;
using System;
using System.Collections.Generic;

namespace Land.Application.Features.CmnMouzaInfo.Queries.GetAllCmnMouzaByUpozilaId
{
    public class GetAllCmnMouzaByUpozilaIdQuery  : IRequest<List<CmnMouzaByUpozilaIdVM>>
    {
        public Guid UpozilaId { get; set; }
    }
}

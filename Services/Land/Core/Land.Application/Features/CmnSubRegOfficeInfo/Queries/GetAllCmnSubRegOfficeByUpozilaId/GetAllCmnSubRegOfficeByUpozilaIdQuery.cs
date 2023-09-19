using MediatR;
using System;
using System.Collections.Generic;

namespace Land.Application.Features.CmnSubRegOfficeInfo.Queries.GetAllCmnSubRegOfficeByUpozilaId
{
    public class GetAllCmnSubRegOfficeByUpozilaIdQuery : IRequest<List<CmnSubRegOfficeByUpozilaIdVM>>
    {
        public Guid UpozilaId { get; set; }
    }
}

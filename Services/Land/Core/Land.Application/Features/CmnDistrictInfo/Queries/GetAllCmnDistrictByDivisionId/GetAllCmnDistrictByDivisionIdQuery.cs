using MediatR;
using System;
using System.Collections.Generic;

namespace Land.Application.Features.CmnDistrictInfo.Queries.GetAllCmnDistrictByDivisionId
{
    public class GetAllCmnDistrictByDivisionIdQuery : IRequest<List<CmnDistrictByDivisionIdVM>>
    {
        public Guid DivisionId { get; set; }
    }
}

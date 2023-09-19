using MediatR;
using System;
using System.Collections.Generic;

namespace Land.Application.Features.CmnUpozilaInfo.Queries.GetAllCmnUpozilaByDistrictId
{
    public class GetAllCmnUpozilaByDistrictIdQuery : IRequest<List<CmnUpozilaByDistrictIdVM>>
    {
        public Guid DistrictId { get; set; }
    }
}

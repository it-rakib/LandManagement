using MediatR;
using System;
using System.Collections.Generic;

namespace Land.Application.Features.LandMasterInfo.Queries.GetAllUpozilaByDistrictIdList
{
    public class GetAllUpozilaByDistrictIdListQuery : IRequest<List<GetAllUpozilaByDistrictIdListVm>>
    {
        public Guid DistrictId { get; set; }
    }
}

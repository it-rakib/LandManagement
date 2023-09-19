using System.Collections.Generic;
using MediatR;

namespace Land.Application.Features.LandMasterInfo.Queries.GetAllLandSummaryDistrictList
{
    public class GetAllLandSummaryDistrictListQuery : IRequest<List<GetAllLandSummaryDistrictListVm>>
    {
    }
}

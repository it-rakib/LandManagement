using MediatR;
using System.Collections.Generic;

namespace Land.Application.Features.CmnDivisionInfo.Queries.GetAllCmnDivisionList
{
    public class GetAllCmnDivisionListQuery : IRequest<List<CmnDivisionListVm>>
    {

    }
}

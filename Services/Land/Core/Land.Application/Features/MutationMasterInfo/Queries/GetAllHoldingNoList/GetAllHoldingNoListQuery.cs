using System.Collections.Generic;
using MediatR;

namespace Land.Application.Features.MutationMasterInfo.Queries.GetAllHoldingNoList
{
    public class GetAllHoldingNoListQuery : IRequest<List<HoldingNoListVm>>
    {
    }
}

using MediatR;
using System.Collections.Generic;

namespace Land.Application.Features.MutationMasterInfo.Queries.GetAllMutatedDeedNoList
{
    public class GetAllMutatedDeedNoListQuery : IRequest<List<MutatedDeedNoListVm>>
    {
    }
}

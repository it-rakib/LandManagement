using MediatR;
using System.Collections.Generic;

namespace Land.Application.Features.LandOwnerInfo.Queries.GetAllOwnerInfoList
{
    public class GetAllOwnerInfoListQuery : IRequest<List<GetAllOwnerInfoListVm>>
    {
    }
}

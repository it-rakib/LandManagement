using MediatR;
using System.Collections.Generic;

namespace Land.Application.Features.LandOwnerTypeInfo.Queries.GetAllLandOwnerTypeList
{
    public class GetAllLandOwnerTypeListQuery : IRequest<List<GetAllLandOwnerTypeListVm>>
    {
    }
}

using MediatR;
using System.Collections.Generic;

namespace Land.Application.Features.LandMasterInfo.Queries.GetAllDeedNoList
{
    public class GetAllDeedNoListQuery : IRequest<List<AllDeedNoListVm>>
    {
    }
}

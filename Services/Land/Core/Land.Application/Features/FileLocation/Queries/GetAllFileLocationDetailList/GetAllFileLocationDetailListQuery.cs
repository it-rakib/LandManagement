using MediatR;
using System.Collections.Generic;

namespace Land.Application.Features.FileLocation.Queries.GetAllFileLocationDetailList
{
    public class GetAllFileLocationDetailListQuery : IRequest<List<FileLocationDetailListVm>>
    {
    }
}

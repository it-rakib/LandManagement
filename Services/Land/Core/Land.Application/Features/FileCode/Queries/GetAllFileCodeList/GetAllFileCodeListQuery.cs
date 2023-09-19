using MediatR;
using System.Collections.Generic;

namespace Land.Application.Features.FileCode.Queries.GetAllFileCodeList
{
    public class GetAllFileCodeListQuery : IRequest<List<FileCodeListVm>>
    {
    }
}

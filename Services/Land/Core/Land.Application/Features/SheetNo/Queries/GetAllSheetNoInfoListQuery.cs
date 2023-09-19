using MediatR;
using System.Collections.Generic;

namespace Land.Application.Features.SheetNo.Queries
{
    public class GetAllSheetNoInfoListQuery : IRequest<List<GetAllSheetNoInfoListVm>>
    {
    }
}

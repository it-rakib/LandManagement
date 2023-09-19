using System.Collections.Generic;
using MediatR;

namespace Land.Application.Features.CmnBanglaYearInfo.Queries.GetAllCmnBanglaYearList
{
    public class GetAllCmnBanglaYearListQuery : IRequest<List<CmnBanglaYearVm>>
    {
    }
}

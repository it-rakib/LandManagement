using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Land.Application.Features.MapTypeInfo.Queries.MapTypeListCombo
{
    public class MapTypeListComboQuery : IRequest<List<MapTypeListComboVm>>
    {
    }
}

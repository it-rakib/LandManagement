using Common.Service.CommonEntities.KendoGrid;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Land.Application.Features.LandMasterInfo.Queries.GetLandInfoGlobalSearch
{
    public class GetLandInfoGlobalSearchQuery : IRequest<GridEntity<GetLandInfoGlobalSearchVm>>
    {
        public GridOptions options { get; set; }
    }
}

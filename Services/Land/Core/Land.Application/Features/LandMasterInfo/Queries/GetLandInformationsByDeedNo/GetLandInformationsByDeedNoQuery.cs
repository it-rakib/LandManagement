using Common.Service.CommonEntities.KendoGrid;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Land.Application.Features.LandMasterInfo.Queries.GetLandInformationsByDeedNo
{
    public class GetLandInformationsByDeedNoQuery : IRequest<GridEntity<GetLandInformationsByDeedNoVm>>
    {
        public GridOptions options { get; set; }
        public string DeedNo { get; set; }
    }
}

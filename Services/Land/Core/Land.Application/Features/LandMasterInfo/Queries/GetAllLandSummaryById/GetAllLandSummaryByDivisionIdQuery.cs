using Common.Service.CommonEntities.KendoGrid;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Land.Application.Features.LandMasterInfo.Queries.GetAllLandSummaryByDivisionId
{
    public class GetAllLandSummaryByDivisionIdQuery : IRequest<GridEntity<GetAllLandSummaryByIdVm>>
    {
        public Guid? DivisionId { get; set; }
        public Guid? DistrictId { get; set; }
        public Guid? UpozilaId { get; set; }
        public Guid? MouzaId { get; set; }
        public Guid? OwnerInfoId { get; set; }
        public GridOptions options { get; set; }
    }
}

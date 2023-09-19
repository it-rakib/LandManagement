using Common.Service.CommonEntities.KendoGrid;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Land.Application.Features.MutationMasterInfo.Queries.GetAllLandMutationSummaryByMouzaId
{
    public class GetAllLandMutationSummaryByMouzaIdQuery : IRequest<GridEntity<GetAllLandMutationSummaryByMouzaIdVm>>
    {
        public GridOptions options { get; set; }
        public Guid mouzaId { get; set; }

        public GetAllLandMutationSummaryByMouzaIdQuery(GridOptions options, Guid mouzaId)
        {
            this.options = options;
            this.mouzaId = mouzaId;
        }
    }
}

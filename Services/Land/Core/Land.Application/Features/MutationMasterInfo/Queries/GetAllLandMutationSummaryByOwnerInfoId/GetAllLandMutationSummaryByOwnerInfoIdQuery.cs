using Common.Service.CommonEntities.KendoGrid;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Land.Application.Features.MutationMasterInfo.Queries.GetAllLandMutationSummaryByOwnerInfoId
{
    public class GetAllLandMutationSummaryByOwnerInfoIdQuery : IRequest<GridEntity<GetAllLandMutationSummaryByOwnerInfoIdVm>>
    {
        public GridOptions options { get; set; }
        public Guid? mouzaId { get; set; }
        public Guid ownerInfoId { get; set; }

        public GetAllLandMutationSummaryByOwnerInfoIdQuery(GridOptions options, Guid? mouzaId, Guid ownerInfoId)
        {
            this.options = options;
            this.mouzaId = mouzaId;
            this.ownerInfoId = ownerInfoId;
        }
    }
}

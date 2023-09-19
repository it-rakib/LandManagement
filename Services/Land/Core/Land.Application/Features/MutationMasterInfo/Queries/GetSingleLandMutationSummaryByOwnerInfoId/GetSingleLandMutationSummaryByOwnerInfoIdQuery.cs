using Common.Service.CommonEntities.KendoGrid;
using Land.Application.Features.MutationMasterInfo.Queries.GetAllLandMutationSummaryByOwnerInfoId;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Land.Application.Features.MutationMasterInfo.Queries.GetSingleLandMutationSummaryByOwnerInfoId
{
    public class GetSingleLandMutationSummaryByOwnerInfoIdQuery : IRequest<GridEntity<GetAllLandMutationSummaryByOwnerInfoIdVm>>
    {
        public GridOptions options { get; set; }
        public Guid ownerInfoId { get; set; }

        public GetSingleLandMutationSummaryByOwnerInfoIdQuery(GridOptions options, Guid ownerInfoId)
        {
            this.options = options;
            this.ownerInfoId = ownerInfoId;
        }

        
    }
}

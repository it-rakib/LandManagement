using Common.Service.CommonEntities.KendoGrid;
using MediatR;
using System;

namespace Land.Application.Features.LandMasterInfo.Queries.GetAllLandMutationSummaryByUpozilaId
{
    public class GetAllLandMutationSummaryByUpozilaIdQuery : IRequest<GridEntity<GetAllLandMutationSummaryByUpozilaIdVm>>
    {
        public Guid UpozilaId { get; set; }
        public GridOptions options { get; set; }

        public GetAllLandMutationSummaryByUpozilaIdQuery(GridOptions options, Guid UpozilaId)
        {
            this.options = options;
            this.UpozilaId = UpozilaId;
        }

        
    }
}

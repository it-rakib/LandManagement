using Common.Service.CommonEntities.KendoGrid;
using MediatR;

namespace Land.Application.Features.MutationMasterInfo.Queries.GetAllMutationMasterGrid
{
    public class GetAllMutationMasterGridQuery : IRequest<GridEntity<GetAllMutationMasterGridVm>>
    {
        public GridOptions options { get; set; }
    }
}

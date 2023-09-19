using Common.Service.CommonEntities.KendoGrid;
using Land.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Land.Application.Features.LandMasterInfo.Queries.GetAllLandSummaryByDivisionId
{
    public class GetLandSummaryByDivisionIdQueryHandler : IRequestHandler<GetLandSummaryByDivisionIdQuery,GridEntity<GetAllLandSummaryByDivisionIdVm>>
    {
        private readonly ILandMasterRepository _landMasterRepository;

        public GetLandSummaryByDivisionIdQueryHandler(ILandMasterRepository landMasterRepository)
        {
            _landMasterRepository = landMasterRepository ?? throw new ArgumentNullException(nameof(landMasterRepository));
        }

        public async Task<GridEntity<GetAllLandSummaryByDivisionIdVm>> Handle(GetLandSummaryByDivisionIdQuery request, CancellationToken cancellationToken)
        {
            var list = await _landMasterRepository.GetAllLandSummaryByDivisionIdGridAsync(request.options,request.DivisionId);
            return list;
        }
    }
}

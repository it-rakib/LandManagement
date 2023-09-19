using Common.Service.CommonEntities.KendoGrid;
using Land.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Land.Application.Features.LandMasterInfo.Queries.GetLandInfoGlobalSearch
{
    public class GetLandInfoGlobalSearchQueryHandler:IRequestHandler<GetLandInfoGlobalSearchQuery,GridEntity<GetLandInfoGlobalSearchVm>>
    {
        private readonly ILandMasterRepository _landMasterRepository;

        public GetLandInfoGlobalSearchQueryHandler(ILandMasterRepository landMasterRepository)
        {
            _landMasterRepository = landMasterRepository ?? throw new ArgumentNullException(nameof(landMasterRepository));
        }

        public async Task<GridEntity<GetLandInfoGlobalSearchVm>> Handle(GetLandInfoGlobalSearchQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _landMasterRepository.GetAllLandSummaryGlobalGridAsync(request.options);
                return data;
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
        }
    }
}

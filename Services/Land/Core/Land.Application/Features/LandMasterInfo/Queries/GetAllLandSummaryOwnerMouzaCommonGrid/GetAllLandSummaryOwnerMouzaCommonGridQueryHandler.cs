using Common.Service.CommonEntities.KendoGrid;
using Land.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Land.Application.Features.LandMasterInfo.Queries.GetAllLandSummaryOwnerMouzaCommonGrid
{
    public class GetAllLandSummaryOwnerMouzaCommonGridQueryHandler : IRequestHandler<GetAllLandSummaryOwnerMouzaCommonGridQuery, GridEntity<GetAllLandSummaryOwnerMouzaCommonGridVm>>
    {
        private readonly ILandMasterRepository _landMasterRepository;

        public GetAllLandSummaryOwnerMouzaCommonGridQueryHandler(ILandMasterRepository landMasterRepository)
        {
            _landMasterRepository = landMasterRepository ?? throw new ArgumentNullException(nameof(landMasterRepository));
        }

        public async Task<GridEntity<GetAllLandSummaryOwnerMouzaCommonGridVm>> Handle(GetAllLandSummaryOwnerMouzaCommonGridQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var list = await _landMasterRepository.GetAllLandSummaryOwnerMouzaCommonGrid(request.options);
                return list;
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }
    }
}

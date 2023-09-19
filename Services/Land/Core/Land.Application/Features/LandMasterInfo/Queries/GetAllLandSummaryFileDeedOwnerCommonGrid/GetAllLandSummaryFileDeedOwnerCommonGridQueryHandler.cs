using Common.Service.CommonEntities.KendoGrid;
using Land.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Land.Application.Features.LandMasterInfo.Queries.GetAllLandSummaryFileDeedOwnerCommonGrid
{
    public class GetAllLandSummaryFileDeedOwnerCommonGridQueryHandler
        : IRequestHandler<GetAllLandSummaryFileDeedOwnerCommonGridQuery, GridEntity<GetAllLandSummaryFileDeedOwnerCommonGridVm>>
    {
        private readonly ILandMasterRepository _landMasterRepository;

        public GetAllLandSummaryFileDeedOwnerCommonGridQueryHandler(ILandMasterRepository landMasterRepository)
        {
            _landMasterRepository = landMasterRepository ?? throw new ArgumentNullException(nameof(landMasterRepository));
        }

        public async Task<GridEntity<GetAllLandSummaryFileDeedOwnerCommonGridVm>> Handle(GetAllLandSummaryFileDeedOwnerCommonGridQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var list = await _landMasterRepository.GetAllLandSummaryFileDeedOwnerCommonGrid(request.options);
                return list;
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }
    }
}



using Common.Service.CommonEntities.KendoGrid;
using Land.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Land.Application.Features.LandMasterInfo.Queries.GetLandSummaryByOwnerId
{
    public class GetLandSummaryByOwnerIdQueryHandler : IRequestHandler<GetLandSummaryByOwnerIdQuery,GridEntity<GetLandSummaryByOwnerIdVm>>
    {
        private readonly ILandMasterRepository _landMasterRepository;

        public GetLandSummaryByOwnerIdQueryHandler(ILandMasterRepository landMasterRepository)
        {
            _landMasterRepository = landMasterRepository ?? throw new ArgumentNullException(nameof(landMasterRepository));
        }

        public async Task<GridEntity<GetLandSummaryByOwnerIdVm>> Handle(GetLandSummaryByOwnerIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await _landMasterRepository.GetAllLandSummaryByOwnerIdGridAsync(request.options,request.MouzaId,request.OwnerInfoId);
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
        }
    }
}

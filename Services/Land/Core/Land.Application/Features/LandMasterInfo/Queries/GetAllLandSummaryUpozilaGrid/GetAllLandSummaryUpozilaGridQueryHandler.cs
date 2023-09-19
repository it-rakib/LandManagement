using Common.Service.CommonEntities.KendoGrid;
using Land.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Land.Application.Features.LandMasterInfo.Queries.GetAllLandSummaryUpozilaGrid
{
    public class GetAllLandSummaryUpozilaGridQueryHandler : IRequestHandler<GetAllLandSummaryUpozilaGridQuery, GridEntity<LandSummaryUpozilaGridVm>>
    {
        private readonly ILandMasterRepository _landMasterRepository;

        public GetAllLandSummaryUpozilaGridQueryHandler(ILandMasterRepository landMasterRepository)
        {
            _landMasterRepository = landMasterRepository ?? throw new ArgumentNullException(nameof(landMasterRepository));
        }

        public async Task<GridEntity<LandSummaryUpozilaGridVm>> Handle(GetAllLandSummaryUpozilaGridQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var list = await _landMasterRepository.GetAllLandSummaryUpozilaGridAsync(request.options);
                return list;
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }
    }
}

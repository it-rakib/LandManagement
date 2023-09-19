using Common.Service.CommonEntities.KendoGrid;
using Land.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Land.Application.Features.LandMasterInfo.Queries.GetAllLandMasterGrid
{
    public class GetAllLandMasterGridQueryHandler : IRequestHandler<GetAllLandMasterGridQuery,GridEntity<GetAllLandMasterGridVm>>
    {
        private readonly ILandMasterRepository _landMasterRepository;

        public GetAllLandMasterGridQueryHandler(ILandMasterRepository landMasterRepository)
        {
            _landMasterRepository = landMasterRepository ?? throw new ArgumentNullException(nameof(landMasterRepository));
        }

        public async Task<GridEntity<GetAllLandMasterGridVm>> Handle(GetAllLandMasterGridQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var list = await _landMasterRepository.GetAllMasterGridAsync(request.options);
                return list;
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }
    }
}

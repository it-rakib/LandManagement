using Common.Service.CommonEntities.KendoGrid;
using Land.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Land.Application.Features.LandMasterInfo.Queries.GetLandInformationsByDeedNo
{
    public class GetLandInformationsByDeedNoQueryHandler : IRequestHandler<GetLandInformationsByDeedNoQuery,GridEntity<GetLandInformationsByDeedNoVm>>
    {
        private readonly ILandMasterRepository _landMasterRepository;

        public GetLandInformationsByDeedNoQueryHandler(ILandMasterRepository landMasterRepository)
        {
            _landMasterRepository = landMasterRepository ?? throw new ArgumentNullException(nameof(landMasterRepository));
        }

        public async Task<GridEntity<GetLandInformationsByDeedNoVm>> Handle(GetLandInformationsByDeedNoQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var list = await _landMasterRepository.GetAllLandInformationsByDeedGrid(request.options, request.DeedNo);
                return list;
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
        }
    }
}

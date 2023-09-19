using Common.Service.CommonEntities.KendoGrid;
using Land.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Land.Application.Features.LandMasterInfo.Queries.GetAllLandSummaryUpozilaByDistrictIdGrid
{
    public class GetAllLandSummaryUpozilaByDistrictIdGridQueryHandler : IRequestHandler<GetAllLandSummaryUpozilaByDistrictIdGridQuery, GridEntity<LandSummaryUpozilaByDistrictIdGridVm>>
    {
        private readonly ILandMasterRepository _landMasterRepository;

        public GetAllLandSummaryUpozilaByDistrictIdGridQueryHandler(ILandMasterRepository landMasterRepository)
        {
            _landMasterRepository = landMasterRepository ?? throw new ArgumentNullException(nameof(landMasterRepository));
        }

        public async Task<GridEntity<LandSummaryUpozilaByDistrictIdGridVm>> Handle(GetAllLandSummaryUpozilaByDistrictIdGridQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var list = await _landMasterRepository.GetAllLandSummaryUpozilaByDistrictIdGridAsync(request.options, request.DistrictId);
                return list;
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }
    }
}

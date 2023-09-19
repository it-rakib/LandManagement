using Common.Service.CommonEntities.KendoGrid;
using Land.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Land.Application.Features.LandMasterInfo.Queries.GetAllLandSummaryMouzaGrid
{
    public class GetAllLandSummaryMouzaGridQueryHandler : IRequestHandler<GetAllLandSummaryMouzaGridQuery, GridEntity<LandSummaryMouzaGridVm>>
    {
        private readonly ILandMasterRepository _landMasterRepository;

        public GetAllLandSummaryMouzaGridQueryHandler(ILandMasterRepository landMasterRepository)
        {
            _landMasterRepository = landMasterRepository ?? throw new ArgumentNullException(nameof(landMasterRepository));
        }

        public async Task<GridEntity<LandSummaryMouzaGridVm>> Handle(GetAllLandSummaryMouzaGridQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var list = await _landMasterRepository.GetAllLandSummaryMouzaGridAsync(request.options);
                return list;
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }
    }
}

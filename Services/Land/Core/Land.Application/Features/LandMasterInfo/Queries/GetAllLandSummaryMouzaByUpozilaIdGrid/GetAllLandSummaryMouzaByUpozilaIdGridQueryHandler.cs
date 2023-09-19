using Common.Service.CommonEntities.KendoGrid;
using Land.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Land.Application.Features.LandMasterInfo.Queries.GetAllLandSummaryMouzaByUpozilaIdGrid
{
    public class GetAllLandSummaryMouzaByUpozilaIdGridQueryHandler : IRequestHandler<GetAllLandSummaryMouzaByUpozilaIdGridQuery, GridEntity<LandSummaryMouzaByUpozilaIdGridVm>>
    {
        private readonly ILandMasterRepository _landMasterRepository;

        public GetAllLandSummaryMouzaByUpozilaIdGridQueryHandler(ILandMasterRepository landMasterRepository)
        {
            _landMasterRepository = landMasterRepository ?? throw new ArgumentNullException(nameof(landMasterRepository));
        }

        public async Task<GridEntity<LandSummaryMouzaByUpozilaIdGridVm>> Handle(GetAllLandSummaryMouzaByUpozilaIdGridQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var list = await _landMasterRepository.GetAllLandSummaryMouzaByUpozilaIdGridAsync(request.options, request.UpozilaId);
                return list;
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }
    }
}

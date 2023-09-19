using Common.Service.CommonEntities.KendoGrid;
using Land.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Land.Application.Features.LandMasterInfo.Queries.GetAllLandSummaryByDivisionId
{
    public class GetAllLandSummaryByDivisionIdQueryHandler : IRequestHandler<GetAllLandSummaryByDivisionIdQuery,GridEntity<GetAllLandSummaryByIdVm>>
    {
        private readonly ILandMasterRepository _landMasterRepository;

        public GetAllLandSummaryByDivisionIdQueryHandler(ILandMasterRepository landMasterRepository)
        {
            _landMasterRepository = landMasterRepository ?? throw new ArgumentNullException(nameof(landMasterRepository));
        }

        public async Task<GridEntity<GetAllLandSummaryByIdVm>> Handle(GetAllLandSummaryByDivisionIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await _landMasterRepository.GetLandSummaryById(request.options,request.DivisionId,request.DistrictId,request.UpozilaId,request.MouzaId,request.OwnerInfoId);
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
        }
    }
}

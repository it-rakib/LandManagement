using Common.Service.CommonEntities.KendoGrid;
using Land.Application.Contracts;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Land.Application.Features.LandOwnersDetailInfo.Queries.GetAllLandSummaryCompanyGrid
{
    public class GetAllLandSummaryCompanyGridQueryHandler : IRequestHandler<GetAllLandSummaryCompanyGridQuery, GridEntity<GetAllLandSummaryCompanyGridVm>>
    {
        private readonly ILandOwnersDetailRepository _landOwnersDetailRepository;

        public GetAllLandSummaryCompanyGridQueryHandler(ILandOwnersDetailRepository landOwnersDetailRepository)
        {
            _landOwnersDetailRepository = landOwnersDetailRepository ?? throw new ArgumentNullException(nameof(landOwnersDetailRepository));
        }

        public async Task<GridEntity<GetAllLandSummaryCompanyGridVm>> Handle(GetAllLandSummaryCompanyGridQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var list = await _landOwnersDetailRepository.GetAllLandSummaryCompanyGridAsync(request.options);
                return list;
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
        }
    }
}

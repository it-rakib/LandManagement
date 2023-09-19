using Common.Service.CommonEntities.KendoGrid;
using Land.Application.Contracts;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Land.Application.Features.LandOwnersDetailInfo.Queries.GetAllLandSummaryPersonGrid
{
    public class GetAllLandSummaryPersonGridQueryHandler : IRequestHandler<GetAllLandSummaryPersonGridQuery, GridEntity<GetAllLandSummaryPersonGridVm>>
    {
        private readonly ILandOwnersDetailRepository _landOwnersDetailRepository;

        public GetAllLandSummaryPersonGridQueryHandler(ILandOwnersDetailRepository landOwnersDetailRepository)
        {
            _landOwnersDetailRepository = landOwnersDetailRepository ?? throw new ArgumentNullException(nameof(landOwnersDetailRepository));
        }

        public async Task<GridEntity<GetAllLandSummaryPersonGridVm>> Handle(GetAllLandSummaryPersonGridQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var list = await _landOwnersDetailRepository.GetAllLandSummaryPersonGridAsync(request.options);
                return list;
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
        }
    }
}

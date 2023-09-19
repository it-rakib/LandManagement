using Common.Service.CommonEntities.KendoGrid;
using Land.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Land.Application.Features.CmnUpozilaInfo.Queries.GetAllCmnUpozilaGrid
{
    public class GetAllCmnUpozilaGridQueryHandler : IRequestHandler<GetAllCmnUpozilaGridQuery, GridEntity<CmnUpozilaGridVM>>
    {
        private readonly ICmnUpozilaRepository _cmnUpozilaRepository;

        public GetAllCmnUpozilaGridQueryHandler(ICmnUpozilaRepository cmnUpozilaRepository)
        {
            _cmnUpozilaRepository = cmnUpozilaRepository ?? throw new ArgumentNullException(nameof(cmnUpozilaRepository));
        }

        public async Task<GridEntity<CmnUpozilaGridVM>> Handle(GetAllCmnUpozilaGridQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _cmnUpozilaRepository.GetAllPagingAsync(request.options);
                return result;
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }
    }
}

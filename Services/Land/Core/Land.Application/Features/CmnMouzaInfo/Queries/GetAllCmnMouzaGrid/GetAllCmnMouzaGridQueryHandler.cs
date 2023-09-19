using Common.Service.CommonEntities.KendoGrid;
using Land.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Land.Application.Features.CmnMouzaInfo.Queries.GetAllCmnMouzaGrid
{
    public class GetAllCmnMouzaGridQueryHandler : IRequestHandler<GetAllCmnMouzaGridQuery, GridEntity<CmnMouzaGridVM>>
    {
        private readonly ICmnMouzaRepository _cmnMouzaRepository;

        public GetAllCmnMouzaGridQueryHandler(ICmnMouzaRepository cmnMouzaRepository)
        {
            _cmnMouzaRepository = cmnMouzaRepository ?? throw new ArgumentNullException(nameof(cmnMouzaRepository));
        }

        public async Task<GridEntity<CmnMouzaGridVM>> Handle(GetAllCmnMouzaGridQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _cmnMouzaRepository.GetAllPagingAsync(request.options);
                return result;
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }
    }
}

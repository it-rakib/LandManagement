using Common.Service.CommonEntities.KendoGrid;
using Land.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Land.Application.Features.LandMapInfo.Queries.GetAllMapInfoGrid
{
    public class GetAllMapInfoGridQueryHandler : IRequestHandler<GetAllMapInfoGridQuery,GridEntity<GetAllMapInfoGridVm>>
    {
        private readonly ILandMapRepository _landMapRepository;

        public GetAllMapInfoGridQueryHandler(ILandMapRepository landMapRepository)
        {
            _landMapRepository = landMapRepository ?? throw new ArgumentNullException(nameof(landMapRepository));
        }

        public async Task<GridEntity<GetAllMapInfoGridVm>> Handle(GetAllMapInfoGridQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var list = await _landMapRepository.GetAllMapGrid(request.options);
                return list;
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
        }
    }
}

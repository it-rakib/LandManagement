using Common.Service.CommonEntities.KendoGrid;
using Land.Application.Contracts.Persistence;
using Land.Application.Features.LandOwnerInfo.Queries.GetAllOwnerGrid;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Land.Application.Features.LandOwnerInfo.Queries.GetAllOwnerInfoGrid
{
    public class GetAllOwnerInfoGridQueryHandler : IRequestHandler<GetAllOwnerInfoGridQuery, GridEntity<OwnerInfoGridVm>>
    {
        private readonly IOwnerInfoRepository _ownerInfoRepository;

        public GetAllOwnerInfoGridQueryHandler(IOwnerInfoRepository ownerInfoRepository)
        {
            _ownerInfoRepository = ownerInfoRepository ?? throw new ArgumentNullException(nameof(ownerInfoRepository));
        }

        public async Task<GridEntity<OwnerInfoGridVm>> Handle(GetAllOwnerInfoGridQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _ownerInfoRepository.GetAllPagingAsync(request.options);
                return result;
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
        }
    }
}

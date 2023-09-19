using Common.Service.CommonEntities.KendoGrid;
using Land.Application.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Land.Application.Features.LandOwnersDetailInfo.Queries.GetAllLandOwnerGrid
{
    public class GetAllLandOwnerGridQueryHandler : IRequestHandler<GetAllLandOwnerGridQuery, GridEntity<LandOwnerGridVm>>
    {
        private readonly ILandOwnersDetailRepository _landOwnersDetailRepository;

        public GetAllLandOwnerGridQueryHandler(ILandOwnersDetailRepository landOwnersDetailRepository)
        {
            _landOwnersDetailRepository = landOwnersDetailRepository ?? throw new ArgumentNullException(nameof(landOwnersDetailRepository));
        }

        public async Task<GridEntity<LandOwnerGridVm>> Handle(GetAllLandOwnerGridQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var list = await _landOwnersDetailRepository.GetAllLandOwnerGridAsync(request.options);
                return list;
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
        }
    }
}

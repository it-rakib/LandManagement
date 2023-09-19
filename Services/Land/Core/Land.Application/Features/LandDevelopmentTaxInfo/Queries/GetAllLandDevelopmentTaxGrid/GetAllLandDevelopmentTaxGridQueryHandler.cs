using System;
using System.Threading;
using System.Threading.Tasks;
using Common.Service.CommonEntities.KendoGrid;
using Land.Application.Contracts.Persistence;
using MediatR;

namespace Land.Application.Features.LandDevelopmentTaxInfo.Queries.GetAllLandDevelopmentTaxGrid
{
    public class GetAllLandDevelopmentTaxGridQueryHandler : IRequestHandler<GetAllLandDevelopmentTaxGridQuery, GridEntity<LandDevelopmentTaxGridVm>>
    {
        private readonly ILandDevelopmentTaxRepository _developmentTaxRepository;

        public GetAllLandDevelopmentTaxGridQueryHandler(ILandDevelopmentTaxRepository developmentTaxRepository)
        {
            _developmentTaxRepository = developmentTaxRepository ?? throw new ArgumentNullException(nameof(developmentTaxRepository));
        }

        public async Task<GridEntity<LandDevelopmentTaxGridVm>> Handle(GetAllLandDevelopmentTaxGridQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var list = await _developmentTaxRepository.GetAllPagingAsync(request.options);
                return list;
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }
    }
}

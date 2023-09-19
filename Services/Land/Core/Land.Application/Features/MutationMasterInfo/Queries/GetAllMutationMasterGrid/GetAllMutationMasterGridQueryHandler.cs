using System;
using System.Threading;
using System.Threading.Tasks;
using Common.Service.CommonEntities.KendoGrid;
using Land.Application.Contracts.Persistence;
using MediatR;

namespace Land.Application.Features.MutationMasterInfo.Queries.GetAllMutationMasterGrid
{
    public class GetAllMutationMasterGridQueryHandler : IRequestHandler<GetAllMutationMasterGridQuery, GridEntity<GetAllMutationMasterGridVm>>
    {
        private readonly IMutationMasterRepository _mutationMasterRepository;

        public GetAllMutationMasterGridQueryHandler(IMutationMasterRepository mutationMasterRepository)
        {
            _mutationMasterRepository = mutationMasterRepository ??throw new ArgumentNullException(nameof(mutationMasterRepository));
        }


        public async Task<GridEntity<GetAllMutationMasterGridVm>> Handle(GetAllMutationMasterGridQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var list = await _mutationMasterRepository.GetAllMasterGridAsync(request.options);
                return list;
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
        }
    }
}

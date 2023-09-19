using Land.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Land.Application.Features.MutationMasterInfo.Queries.GetAllHoldingNoList
{
    public class GetAllHoldingNoListQueryHandler : IRequestHandler<GetAllHoldingNoListQuery, List<HoldingNoListVm>>
    {
        private readonly IMutationMasterRepository _mutationMasterRepository;

        public GetAllHoldingNoListQueryHandler(IMutationMasterRepository mutationMasterRepository)
        {
            _mutationMasterRepository = mutationMasterRepository ?? throw new ArgumentNullException(nameof(mutationMasterRepository));
        }

        public async Task<List<HoldingNoListVm>> Handle(GetAllHoldingNoListQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await _mutationMasterRepository.GetAllHoldingNo();
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
        }
    }
}

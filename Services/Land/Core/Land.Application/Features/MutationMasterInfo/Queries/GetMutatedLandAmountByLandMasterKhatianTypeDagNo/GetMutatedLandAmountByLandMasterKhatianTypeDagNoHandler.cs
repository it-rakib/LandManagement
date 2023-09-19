using Land.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Land.Application.Features.MutationMasterInfo.Queries.GetMutatedLandAmountByLandMasterKhatianTypeDagNo
{
    public class GetMutatedLandAmountByLandMasterKhatianTypeDagNoHandler
        : IRequestHandler<GetMutatedLandAmountByLandMasterKhatianTypeDagNoQuery, decimal>
    {
        private readonly IMutationMasterRepository _mutationMasterRepository;

        public GetMutatedLandAmountByLandMasterKhatianTypeDagNoHandler(IMutationMasterRepository mutationMasterRepository)
        {
            _mutationMasterRepository = mutationMasterRepository ?? throw new ArgumentNullException(nameof(mutationMasterRepository));
        }

        public Task<decimal> Handle(GetMutatedLandAmountByLandMasterKhatianTypeDagNoQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return _mutationMasterRepository.GetTotalPlotWiseMutatedLandAmountByLandMasterKhatianTypeDagNo(request.LandMasterId, request.KhatianTypeId, request.DagNo);
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }
    }
}

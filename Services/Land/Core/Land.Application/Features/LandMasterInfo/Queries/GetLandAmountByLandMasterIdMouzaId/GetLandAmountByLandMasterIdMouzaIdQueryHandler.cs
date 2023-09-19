using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Land.Application.Contracts.Persistence;
using MediatR;

namespace Land.Application.Features.LandMasterInfo.Queries.GetLandAmountByLandMasterIdMouzaId
{
    public class GetLandAmountByLandMasterIdMouzaIdQueryHandler : IRequestHandler<GetLandAmountByLandMasterIdMouzaIdQuery, decimal>
    {
        private readonly ILandMasterRepository _landMasterRepository;

        public GetLandAmountByLandMasterIdMouzaIdQueryHandler(ILandMasterRepository landMasterRepository)
        {
            _landMasterRepository = landMasterRepository ?? throw new ArgumentNullException(nameof(landMasterRepository));
        }
        public async Task<decimal> Handle(GetLandAmountByLandMasterIdMouzaIdQuery request, CancellationToken cancellationToken)
        {
            var data = await _landMasterRepository.GetLandAmountByLandMasterIdMouzaId(request.LandMasterId, request.MouzaId);
            //var data = await _landMasterRepository.GetLandAmountByLandMasterIdMouzaId(request.LandMasterId);
            return data;
        }
    }
}

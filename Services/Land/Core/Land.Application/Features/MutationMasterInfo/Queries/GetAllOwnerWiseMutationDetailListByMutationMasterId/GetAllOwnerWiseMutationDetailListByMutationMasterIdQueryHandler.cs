using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Land.Application.Contracts.Persistence;
using MediatR;

namespace Land.Application.Features.MutationMasterInfo.Queries.GetAllOwnerWiseMutationDetailListByMutationMasterId
{
    public class GetAllOwnerWiseMutationDetailListByMutationMasterIdQueryHandler : IRequestHandler<GetAllOwnerWiseMutationDetailListByMutationMasterIdQuery, List<OwnerWiseMutationDetailListByMutationMasterIdVm>>
    {
        private readonly IMutationMasterRepository _mutationMasterRepository;
        private readonly IMapper _mapper;

        public GetAllOwnerWiseMutationDetailListByMutationMasterIdQueryHandler(IMutationMasterRepository mutationMasterRepository, IMapper mapper)
        {
            _mutationMasterRepository = mutationMasterRepository ??throw new ArgumentNullException(nameof(mutationMasterRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }


        public async Task<List<OwnerWiseMutationDetailListByMutationMasterIdVm>> Handle(GetAllOwnerWiseMutationDetailListByMutationMasterIdQuery request, CancellationToken cancellationToken)
        {
            var data = await _mutationMasterRepository.GetAllOwnerWiseMutationDetailListByMutationMasterId(request.MutationMasterId);
            var mutationDetails = _mapper.Map<List<OwnerWiseMutationDetailListByMutationMasterIdVm>>(data);
            return mutationDetails;
        }
    }
}

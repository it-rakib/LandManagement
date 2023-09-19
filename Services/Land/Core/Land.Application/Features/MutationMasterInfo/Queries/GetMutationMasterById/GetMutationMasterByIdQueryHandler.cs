using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Common.Service.Repositories;
using Land.Domain.Models;
using MediatR;

namespace Land.Application.Features.MutationMasterInfo.Queries.GetMutationMasterById
{
    public class GetMutationMasterByIdQueryHandler : IRequestHandler<GetMutationMasterByIdQuery, MutationMasterByIdVm>
    {
        private readonly IAsyncRepository<MutationMaster> _mutationMasterRepository;
        private readonly IMapper _mapper;

        public GetMutationMasterByIdQueryHandler(IAsyncRepository<MutationMaster> mutationMasterRepository,
            IMapper mapper)
        {
            _mutationMasterRepository = mutationMasterRepository ?? throw new ArgumentNullException(nameof(mutationMasterRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<MutationMasterByIdVm> Handle(GetMutationMasterByIdQuery request, CancellationToken cancellationToken)
        {
            var mutationMaster = await _mutationMasterRepository.GetByIdAsync(request.MutationMasterId);
            var singleMutationMaster = _mapper.Map<MutationMasterByIdVm>(mutationMaster);
            return singleMutationMaster;
        }
    }
}

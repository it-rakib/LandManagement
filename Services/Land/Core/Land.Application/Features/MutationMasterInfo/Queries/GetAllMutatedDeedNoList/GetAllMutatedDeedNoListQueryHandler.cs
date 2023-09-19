using AutoMapper;
using Land.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Land.Application.Features.MutationMasterInfo.Queries.GetAllMutatedDeedNoList
{
    public class GetAllMutatedDeedNoListQueryHandler : IRequestHandler<GetAllMutatedDeedNoListQuery, List<MutatedDeedNoListVm>>
    {
        private readonly IMutationMasterRepository _mutationMasterRepository;
        private readonly IMapper _mapper;

        public GetAllMutatedDeedNoListQueryHandler(IMutationMasterRepository mutationMasterRepository, IMapper mapper)
        {
            _mutationMasterRepository = mutationMasterRepository ?? throw new ArgumentNullException(nameof(mutationMasterRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<MutatedDeedNoListVm>> Handle(GetAllMutatedDeedNoListQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var list = await _mutationMasterRepository.GetAllMutatedDeedNoList();
                var deedNoList = _mapper.Map<List<MutatedDeedNoListVm>>(list);
                return deedNoList;
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
        }
    }
}

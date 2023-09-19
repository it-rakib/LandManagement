using AutoMapper;
using Common.Service.Repositories;
using Land.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Land.Application.Features.LandOwnerInfo.Queries.GetAllOwnerInfoList
{
    public class GetAllOwnerInfoListQueryHandler : IRequestHandler<GetAllOwnerInfoListQuery,List<GetAllOwnerInfoListVm>>
    {
        private readonly IAsyncRepository<OwnerInfo> _ownerInfoRepository;
        private readonly IMapper _mapper;

        public GetAllOwnerInfoListQueryHandler(IAsyncRepository<OwnerInfo> ownerInfoRepository, IMapper mapper)
        {
            _ownerInfoRepository = ownerInfoRepository ?? throw new ArgumentNullException(nameof(ownerInfoRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<GetAllOwnerInfoListVm>> Handle(GetAllOwnerInfoListQuery request, CancellationToken cancellationToken)
        {
            var list = (await _ownerInfoRepository.GetAllAsync()).OrderBy(o=>o.OwnerInfoName);
            return _mapper.Map<List<GetAllOwnerInfoListVm>>(list);
        }
    }
}

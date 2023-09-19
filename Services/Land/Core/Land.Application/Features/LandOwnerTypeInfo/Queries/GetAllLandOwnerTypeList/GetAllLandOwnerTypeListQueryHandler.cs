using AutoMapper;
using Land.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Land.Application.Features.LandOwnerTypeInfo.Queries.GetAllLandOwnerTypeList
{
    public class GetAllLandOwnerTypeListQueryHandler : IRequestHandler<GetAllLandOwnerTypeListQuery,List<GetAllLandOwnerTypeListVm>>
    {
        private readonly ILandOwnerTypeRepository _landOwnerTypeRepository;
        private readonly IMapper _mapper;

        public GetAllLandOwnerTypeListQueryHandler(ILandOwnerTypeRepository landOwnerTypeRepository, IMapper mapper)
        {
            _landOwnerTypeRepository = landOwnerTypeRepository ?? throw new ArgumentNullException(nameof(landOwnerTypeRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<GetAllLandOwnerTypeListVm>> Handle(GetAllLandOwnerTypeListQuery request, CancellationToken cancellationToken)
        {
            var list = (await _landOwnerTypeRepository.GetAllLandOwnerTypeAsync());
            return _mapper.Map<List<GetAllLandOwnerTypeListVm>>(list);
        }
    }
}

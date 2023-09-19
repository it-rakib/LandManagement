using AutoMapper;
using Common.Service.Repositories;
using Land.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Land.Application.Features.KhatiyanTypeInfo.Queries.GetAllKhatiyanTypes
{
    public class GetAllKhatiyanTypesQueryHandler : IRequestHandler<GetAllKhatiyanTypesQuery,List<GetAllKhatiyanTypesVm>>
    {
        private readonly IAsyncRepository<KhatianType> _khatiyanTypeRepository;
        private readonly IMapper _mapper;

        public GetAllKhatiyanTypesQueryHandler(IAsyncRepository<KhatianType> khatiyanTypeRepository, IMapper mapper)
        {
            _khatiyanTypeRepository = khatiyanTypeRepository ?? throw new ArgumentNullException(nameof(khatiyanTypeRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<GetAllKhatiyanTypesVm>> Handle(GetAllKhatiyanTypesQuery request, CancellationToken cancellationToken)
        {
            var list = (await _khatiyanTypeRepository.GetAllAsync()).OrderBy(o => o.OrderBy);
            return _mapper.Map<List<GetAllKhatiyanTypesVm>>(list);
        }
    }
}

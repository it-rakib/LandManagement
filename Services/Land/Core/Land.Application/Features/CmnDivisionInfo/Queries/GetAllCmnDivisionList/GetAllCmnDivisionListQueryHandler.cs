using AutoMapper;
using Common.Service.Repositories;
using Land.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Land.Application.Features.CmnDivisionInfo.Queries.GetAllCmnDivisionList
{
    public class GetAllCmnDivisionListQueryHandler : IRequestHandler<GetAllCmnDivisionListQuery, List<CmnDivisionListVm>>
    {
        private readonly IAsyncRepository<CmnDivision> _cmnDivisionRepository;
        private readonly IMapper _mapper;

        public GetAllCmnDivisionListQueryHandler(IAsyncRepository<CmnDivision> cmnDivisionRepository, IMapper mapper)
        {
            _cmnDivisionRepository = cmnDivisionRepository ?? throw new ArgumentNullException(nameof(cmnDivisionRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<CmnDivisionListVm>> Handle(GetAllCmnDivisionListQuery request, CancellationToken cancellationToken)
        {
            var list = (await _cmnDivisionRepository.GetAllAsync()).OrderBy(x => x.DivisionName);
            return _mapper.Map<List<CmnDivisionListVm>>(list);
        }
    }
}

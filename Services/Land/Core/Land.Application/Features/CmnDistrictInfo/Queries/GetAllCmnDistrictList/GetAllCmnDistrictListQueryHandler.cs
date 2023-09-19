using AutoMapper;
using Common.Service.Repositories;
using Land.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Land.Application.Features.CmnDistrictInfo.Queries.GetAllCmnDistrictList
{
    public class GetAllCmnDistrictListQueryHandler : IRequestHandler<GetAllCmnDistrictListQuery, List<CmnDistrictListVm>>
    {
        private readonly IAsyncRepository<CmnDistrict> _cmnDistrictRepository;
        private readonly IMapper _mapper;

        public GetAllCmnDistrictListQueryHandler(IAsyncRepository<CmnDistrict> cmnDistrictRepository, IMapper mapper)
        {
            _cmnDistrictRepository = cmnDistrictRepository ?? throw new ArgumentNullException(nameof(cmnDistrictRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<CmnDistrictListVm>> Handle(GetAllCmnDistrictListQuery request, CancellationToken cancellationToken)
        {
            var list = (await _cmnDistrictRepository.GetAllAsync()).OrderBy(x => x.DistrictName);
            return _mapper.Map<List<CmnDistrictListVm>>(list);
        }
    }
}

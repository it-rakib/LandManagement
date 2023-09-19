using AutoMapper;
using Land.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Land.Application.Features.CmnDistrictInfo.Queries.GetAllCmnDistrictByDivisionId
{
    public class GetAllCmnDistrictByDivisionIdQueryHandler : IRequestHandler<GetAllCmnDistrictByDivisionIdQuery, List<CmnDistrictByDivisionIdVM>>
    {
        private readonly ICmnDistrictRepository _cmnDistrictRepository;
        private readonly IMapper _mapper;

        public GetAllCmnDistrictByDivisionIdQueryHandler(ICmnDistrictRepository cmnDistrictRepository, IMapper mapper)
        {
            _cmnDistrictRepository = cmnDistrictRepository ?? throw new ArgumentNullException(nameof(cmnDistrictRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<CmnDistrictByDivisionIdVM>> Handle(GetAllCmnDistrictByDivisionIdQuery request, CancellationToken cancellationToken)
        {
            var district = await _cmnDistrictRepository.GetDistrictListByDivisionIdAsync(request.DivisionId);
            var districtList = _mapper.Map<List<CmnDistrictByDivisionIdVM>>(district);
            return districtList;
        }
    }
}

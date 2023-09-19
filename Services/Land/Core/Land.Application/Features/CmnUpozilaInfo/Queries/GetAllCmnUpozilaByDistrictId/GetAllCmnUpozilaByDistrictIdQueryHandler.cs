using AutoMapper;
using Land.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Land.Application.Features.CmnUpozilaInfo.Queries.GetAllCmnUpozilaByDistrictId
{
    public class GetAllCmnUpozilaByDistrictIdQueryHandler : IRequestHandler<GetAllCmnUpozilaByDistrictIdQuery, List<CmnUpozilaByDistrictIdVM>>
    {
        private readonly ICmnUpozilaRepository _cmnUpozilaRepository;
        private readonly IMapper _mapper;

        public GetAllCmnUpozilaByDistrictIdQueryHandler(ICmnUpozilaRepository cmnUpozilaRepository, IMapper mapper)
        {
            _cmnUpozilaRepository = cmnUpozilaRepository ?? throw new ArgumentNullException(nameof(cmnUpozilaRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<CmnUpozilaByDistrictIdVM>> Handle(GetAllCmnUpozilaByDistrictIdQuery request, CancellationToken cancellationToken)
        {
            var upozila = await _cmnUpozilaRepository.GetUpozilaByDistrictIdAsync(request.DistrictId);
            var upozilaList = _mapper.Map<List<CmnUpozilaByDistrictIdVM>>(upozila);
            return upozilaList;
        }
    }
}

using AutoMapper;
using Common.Service.Repositories;
using Land.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Land.Application.Features.MapTypeInfo.Queries.MapTypeListCombo
{
    public class MapTypeListComboQueryHandler : IRequestHandler<MapTypeListComboQuery,List<MapTypeListComboVm>>
    {
        private readonly IAsyncRepository<MapType> _mapTypeRepository;
        private readonly IMapper _mapper;

        public MapTypeListComboQueryHandler(IAsyncRepository<MapType> mapTypeRepository, IMapper mapper)
        {
            _mapTypeRepository = mapTypeRepository ?? throw new ArgumentNullException(nameof(mapTypeRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<MapTypeListComboVm>> Handle(MapTypeListComboQuery request, CancellationToken cancellationToken)
        {
            var list = (await _mapTypeRepository.GetAllAsync());
            return _mapper.Map<List<MapTypeListComboVm>>(list);
        }
    }
}

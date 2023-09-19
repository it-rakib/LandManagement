using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Common.Service.Repositories;
using Land.Application.Contracts.Persistence;
using Land.Domain.Models;
using MediatR;

namespace Land.Application.Features.LandMasterInfo.Queries.GetAllDeedNoListByMouzaId
{
    public class GetAllDeedNoListByMouzaIdQueryHandler : IRequestHandler<GetAllDeedNoListByMouzaIdQuery, List<DeedNoListByMouzaIdVm>>
    {
        private readonly ILandMasterRepository _landMasterRepository;
        private readonly IMapper _mapper;

        public GetAllDeedNoListByMouzaIdQueryHandler(ILandMasterRepository landMasterRepository, IMapper mapper)
        {
            _landMasterRepository = landMasterRepository ?? throw new ArgumentNullException(nameof(landMasterRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<DeedNoListByMouzaIdVm>> Handle(GetAllDeedNoListByMouzaIdQuery request, CancellationToken cancellationToken)
        {
            var list = await _landMasterRepository.GetDeedNoListByMouzaId(request.MouzaId);
            var data = _mapper.Map<List<DeedNoListByMouzaIdVm>>(list);
            return data;
        }
    }
}

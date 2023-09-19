using AutoMapper;
using Land.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Land.Application.Features.RackNo.Queries.GetAllRackNoListByAlmirahId
{
    public class GetAllRackNoListByAlmirahIdQueryHandler : IRequestHandler<GetAllRackNoListByAlmirahIdQuery, List<RackNoListByAlmirahIdVm>>
    {
        private readonly IRackNoRepository _rackNoRepository;
        private readonly IMapper _mapper;

        public GetAllRackNoListByAlmirahIdQueryHandler(IRackNoRepository rackNoRepository, IMapper mapper)
        {
            _rackNoRepository = rackNoRepository ?? throw new ArgumentNullException(nameof(rackNoRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<RackNoListByAlmirahIdVm>> Handle(GetAllRackNoListByAlmirahIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var rackNoList = await _rackNoRepository.GetAllRackNoListByAlmirahId(request.AlmirahNoInfoId);
                return rackNoList;
            }
            catch (Exception ex)
            {
                throw ex.InnerException; 
            }
        }
    }
}

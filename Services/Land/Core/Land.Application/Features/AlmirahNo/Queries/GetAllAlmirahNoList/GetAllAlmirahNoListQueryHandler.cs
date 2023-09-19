using AutoMapper;
using Land.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Land.Application.Features.AlmirahNo.Queries.GetAllAlmirahNoList
{
    public class GetAllAlmirahNoListQueryHandler : IRequestHandler<GetAllAlmirahNoListQuery, List<AlmirahNoListVm>>
    {
        private readonly IAlmirahNoRepository _almirahNoRepository;
        private readonly IMapper _mapper;

        public GetAllAlmirahNoListQueryHandler(IAlmirahNoRepository almirahNoRepository, IMapper mapper)
        {
            _almirahNoRepository = almirahNoRepository ?? throw new ArgumentNullException(nameof(almirahNoRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<AlmirahNoListVm>> Handle(GetAllAlmirahNoListQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var list = (await _almirahNoRepository.GetAllAsync()).OrderBy(x => x.AlmirahNoInfoName);
                return _mapper.Map<List<AlmirahNoListVm>>(list);
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }
    }
}

using AutoMapper;
using Land.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Land.Application.Features.LandMasterInfo.Queries.GetAllDeedNoList
{
    public class GetAllDeedNoListQueryHandler : IRequestHandler<GetAllDeedNoListQuery, List<AllDeedNoListVm>>
    {
        private readonly ILandMasterRepository _landMasterRepository;
        private readonly IMapper _mapper;

        public GetAllDeedNoListQueryHandler(ILandMasterRepository landMasterRepository, IMapper mapper)
        {
            _landMasterRepository = landMasterRepository ?? throw new ArgumentNullException(nameof(landMasterRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<AllDeedNoListVm>> Handle(GetAllDeedNoListQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var list = await _landMasterRepository.GetAllDeedNoList();
                var deedNoList = _mapper.Map<List<AllDeedNoListVm>>(list);
                return deedNoList;
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }
    }
}

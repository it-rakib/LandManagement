using AutoMapper;
using Land.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Land.Application.Features.LandMasterInfo.Queries.GetAllDeedNoByOwnerInfoId
{
    public class GetAllDeedNoByOwnerInfoIdQueryHandler : IRequestHandler<GetAllDeedNoByOwnerInfoIdQuery, List<DeedNoByOwnerInfoIdVm>>
    {
        private readonly ILandMasterRepository _landMasterRepository;
        private readonly IMapper _mapper;

        public GetAllDeedNoByOwnerInfoIdQueryHandler(ILandMasterRepository landMasterRepository, IMapper mapper)
        {
            _landMasterRepository = landMasterRepository ?? throw new ArgumentNullException(nameof(landMasterRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<DeedNoByOwnerInfoIdVm>> Handle(GetAllDeedNoByOwnerInfoIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var list = await _landMasterRepository.GetAllDeedNoByOwnerInfoId(request.OwnerInfoId);
                var deedNoList = _mapper.Map<List<DeedNoByOwnerInfoIdVm>>(list);
                return deedNoList;
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
        }
    }
}

using AutoMapper;
using Land.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Land.Application.Features.MutationMasterInfo.Queries.GetAllTransferedOwnerInfoByLandMasterKhatianTypeId
{
    public class GetAllTransferedOwnerInfoByLandMasterKhatianTypeIdQueryHandler
        : IRequestHandler<GetAllTransferedOwnerInfoByLandMasterKhatianTypeIdQuery, List<TransferedOwnerInfoByLandMasterKhatianTypeIdVm>>
    {
        private readonly IMutationMasterRepository _mutationMasterRepository;
        private readonly IMapper _mapper;

        public GetAllTransferedOwnerInfoByLandMasterKhatianTypeIdQueryHandler(IMutationMasterRepository mutationMasterRepository, IMapper mapper)
        {
            _mutationMasterRepository = mutationMasterRepository ?? throw new ArgumentNullException(nameof(mutationMasterRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<TransferedOwnerInfoByLandMasterKhatianTypeIdVm>> Handle(GetAllTransferedOwnerInfoByLandMasterKhatianTypeIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var list = await _mutationMasterRepository.GetAllTransferedOwnerInfoByLandMasterKhatianTypeId(request.LandMasterId, request.KhatianTypeId);
                var ownerIfoList = _mapper.Map<List<TransferedOwnerInfoByLandMasterKhatianTypeIdVm>>(list);
                return ownerIfoList;
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }
    }
}

using AutoMapper;
using Land.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Land.Application.Features.MutationMasterInfo.Queries.GetAllDagNoListByLandMasterKhatianType
{
    public class GetAllDagNoListByLandMasterKhatianTypeQueryHandler : IRequestHandler<GetAllDagNoListByLandMasterKhatianTypeQuery, List<DagNoListByLandMasterKhatianTypeVm>>
    {
        private readonly IMutationMasterRepository _mutationMasterRepository;
        private readonly IMapper _mapper;

        public GetAllDagNoListByLandMasterKhatianTypeQueryHandler(IMutationMasterRepository mutationMasterRepository, IMapper mapper)
        {
            _mutationMasterRepository = mutationMasterRepository ?? throw new ArgumentNullException(nameof(mutationMasterRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<DagNoListByLandMasterKhatianTypeVm>> Handle(GetAllDagNoListByLandMasterKhatianTypeQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var list = await _mutationMasterRepository.GetAllDagNoListByLandMasterKhatianType(request.LandMasterId, request.KhatianTypeId);
                var dagNoList = _mapper.Map<List<DagNoListByLandMasterKhatianTypeVm>>(list);
                return dagNoList;
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
        }
    }
}

using AutoMapper;
using Land.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Land.Application.Features.MutationMasterInfo.Queries.GetAllPlotWiseMutationDetailListByMutationMasterId
{
    public class GetAllPlotWiseMutationDetailListByMutationMasterIdQueryHandler : IRequestHandler<GetAllPlotWiseMutationDetailListByMutationMasterIdQuery, List<PlotWiseMutationDetailListByMutationMasterIdVm>>
    {
        private readonly IMutationMasterRepository _mutationMasterRepository;
        private readonly IMapper _mapper;

        public GetAllPlotWiseMutationDetailListByMutationMasterIdQueryHandler(IMutationMasterRepository mutationMasterRepository, IMapper mapper)
        {
            _mutationMasterRepository = mutationMasterRepository ?? throw new ArgumentNullException(nameof(mutationMasterRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<PlotWiseMutationDetailListByMutationMasterIdVm>> Handle(GetAllPlotWiseMutationDetailListByMutationMasterIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _mutationMasterRepository.GetAllPlotWiseMutationDetailListByMutationMasterId(request.MutationMasterId);
                var plotWiseMutationDetails = _mapper.Map<List<PlotWiseMutationDetailListByMutationMasterIdVm>>(data);
                return plotWiseMutationDetails;
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
        }
    }
}

using AutoMapper;
using Land.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Land.Application.Features.LandMasterInfo.Queries.GetAllPlotWiseLandTransferDetailByLandMasterId
{
    public class GetAllPlotWiseLandTransferDetailByLandMasterIdQueryHandler
        : IRequestHandler<GetAllPlotWiseLandTransferDetailByLandMasterIdQuery, List<PlotWiseLandTransferDetailByLandMasterIdVm>>
    {
        private readonly ILandMasterRepository _landMasterRepository;
        private readonly IMapper _mapper;

        public GetAllPlotWiseLandTransferDetailByLandMasterIdQueryHandler(ILandMasterRepository landMasterRepository, IMapper mapper)
        {
            _landMasterRepository = landMasterRepository ?? throw new ArgumentNullException(nameof(landMasterRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<PlotWiseLandTransferDetailByLandMasterIdVm>> Handle(GetAllPlotWiseLandTransferDetailByLandMasterIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _landMasterRepository.GetAllPlotWiseLandTransferDetailByLandMasterId(request.LandMasterId);
                var plotWiseLandTransferDetails = _mapper.Map<List<PlotWiseLandTransferDetailByLandMasterIdVm>>(data);
                return plotWiseLandTransferDetails;
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
        }
    }
}

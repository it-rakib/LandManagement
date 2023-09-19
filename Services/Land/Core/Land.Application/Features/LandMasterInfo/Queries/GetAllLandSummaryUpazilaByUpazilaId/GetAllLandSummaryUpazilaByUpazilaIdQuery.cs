using MediatR;
using System;

namespace Land.Application.Features.LandMasterInfo.Queries.GetAllLandSummaryUpazilaByUpazilaId
{
    public class GetAllLandSummaryUpazilaByUpazilaIdQuery : IRequest<LandSummaryUpazilaByUpazilaIdVm>
    {
        public Guid UpozilaId { get; set; }
    }
}

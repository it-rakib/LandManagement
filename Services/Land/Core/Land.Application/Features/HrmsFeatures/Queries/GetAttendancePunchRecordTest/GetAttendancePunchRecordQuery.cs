using MediatR;
using System.Collections.Generic;

namespace Merchandising.Application.Features.HrmsFeatures.Queries.GetAttendancePunchRecordTest
{
    public class GetAttendancePunchRecordQuery : IRequest<List<GetAttendancePunchRecordVm>>
    {
    }
}

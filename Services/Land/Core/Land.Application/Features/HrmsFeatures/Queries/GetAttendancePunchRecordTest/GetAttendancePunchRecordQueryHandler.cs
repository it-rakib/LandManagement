using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Merchandising.Application.Features.HrmsFeatures.Queries.GetAttendancePunchRecordTest
{
    public class GetAttendancePunchRecordQueryHandler : IRequestHandler<GetAttendancePunchRecordQuery, List<GetAttendancePunchRecordVm>>
    {
        public Task<List<GetAttendancePunchRecordVm>> Handle(GetAttendancePunchRecordQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

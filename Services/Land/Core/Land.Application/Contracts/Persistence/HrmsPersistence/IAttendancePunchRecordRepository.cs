using Merchandising.Application.Features.HrmsFeatures.Queries.GetAttendancePunchRecordTest;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Merchandising.Application.Contracts.Persistence.HrmsPersistence
{
    public interface IAttendancePunchRecordRepository
    {
        Task<List<GetAttendancePunchRecordVm>> GetAllPunchRecord();
    }
}

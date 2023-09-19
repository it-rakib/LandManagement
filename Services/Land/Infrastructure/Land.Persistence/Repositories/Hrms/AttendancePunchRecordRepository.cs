using Merchandising.Application.Contracts.Persistence.HrmsPersistence;
using Merchandising.Application.Features.HrmsFeatures.Queries.GetAttendancePunchRecordTest;
using Merchandising.Domain.HrmsModels;
using Merchandising.Persistence.BaseRepositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Merchandising.Persistence.Repositories.Hrms
{
    public class AttendancePunchRecordRepository : HrmsBaseRepository<GetAttendancePunchRecordVm>, IAttendancePunchRecordRepository
    {
        public AttendancePunchRecordRepository(CoreERPContext context) : base(context)
        {

        }

        public async Task<List<GetAttendancePunchRecordVm>> GetAllPunchRecord()
        {
            return await _dbContext.AttendanceDailyPunchRecords.AsNoTrackingWithIdentityResolution()
                .Select(s => new GetAttendancePunchRecordVm
                {
                    PunchNo = s.PunchNo,
                    PunchTime = s.PunchTime,
                    DeviceNo = s.DeviceNo,
                    DoorMode = s.DoorMode,
                    UserID = s.UserId,
                    AlternativePunchId = s.AlternativePunchId,
                }).ToListAsync();

        }
    }
}

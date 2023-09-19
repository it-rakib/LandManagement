using System;

namespace Merchandising.Application.Features.HrmsFeatures.Queries.GetAttendancePunchRecordTest
{
    public class GetAttendancePunchRecordVm
    {
        public long Id { get; set; }

        public int PunchNo { get; set; }

        public DateTime PunchTime { get; set; }

        public string DeviceNo { get; set; }

        public int DoorMode { get; set; }

        public int UserID { get; set; }

        public DateTime ActionTime { get; set; }

        public bool InActive { get; set; }

        public int? InActiveBy { get; set; }

        public DateTime? InActiveDate { get; set; }

        public long? AlternativePunchId { get; set; }

        public string Remarks { get; set; }
    }
}

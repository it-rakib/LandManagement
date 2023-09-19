using System;
using System.Collections.Generic;

namespace Merchandising.Domain.HrmsModels
{
    public partial class AttendanceDailyPunchRecord
    {
        public long Id { get; set; }
        public int PunchNo { get; set; }
        public DateTime PunchTime { get; set; }
        public string DeviceNo { get; set; }
        /// <summary>
        /// 0=In Mood,1= Out Mood
        /// </summary>
        public int DoorMode { get; set; }
        public int UserId { get; set; }
        public DateTime ActionTime { get; set; }
        public bool InActive { get; set; }
        public int? InActiveBy { get; set; }
        public DateTime? InActiveDate { get; set; }
        public long? AlternativePunchId { get; set; }
        public string Remarks { get; set; }
    }
}

using System;

namespace Land.Application.Features.LandMasterInfo.Queries.GetAllKhatianDetailListByLandMasterIdMouzaIdKhatianTypeId
{
    public class KhatianDetailListByLandMasterIdMouzaIdKhatianTypeIdVm
    {
        public Guid KhatianDetailId { get; set; }
        public Guid LandMasterId { get; set; }
        public Guid MouzaId { get; set; }
        public string MouzaName { get; set; }
        public Guid KhatianTypeId { get; set; }
        public string KhatianTypeName { get; set; }
        //public int? KhatianNo { get; set; }
        public string? KhatianNo { get; set; }
        public string DagNo { get; set; }
        public string RecordedOwnerName { get; set; }
    }
}

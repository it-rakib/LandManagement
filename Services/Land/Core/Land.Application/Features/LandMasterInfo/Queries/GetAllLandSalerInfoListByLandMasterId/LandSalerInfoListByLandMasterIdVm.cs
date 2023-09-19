using System;

namespace Land.Application.Features.LandMasterInfo.Queries.GetAllLandSalerInfoListByLandMasterId
{
    public class LandSalerInfoListByLandMasterIdVm
    {
        public Guid SalersInfoId { get; set; }
        public Guid LandMasterId { get; set; }
        public string SalerName { get; set; }
        public string SalerFatherName { get; set; }
        public string SalerAddress { get; set; }
    }
}

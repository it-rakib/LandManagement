using System;
using System.Collections.Generic;

namespace Land.Application.Features.LandMasterInfo.Queries.GetAllLandOwnerListByLandMasterId
{
    public class LandOwnerListByLandMasterIdVm
    {
        public Guid LandOwnersDetailId { get; set; }
        public Guid LandMasterId { get; set; }
        public Guid OwnerInfoId { get; set; }
        public string OwnerInfoName { get; set; }
        public string SaleOwnerName { get; set; }
        public Guid MouzaId { get; set; }
        public string MouzaName { get; set; }
        public decimal? LandAmount { get; set; }
        public decimal? OwnerRegAmount { get; set; }
        public decimal? OwnerPurchaseAmount { get; set; }
    }
}

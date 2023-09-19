using System;

namespace Land.Application.Features.MutationMasterInfo.Queries.GetMutationMasterById
{
    public class MutationMasterByIdVm
    {
        public Guid MutationMasterId { get; set; }
        public Guid DivisionId { get; set; }
        public Guid DistrictId { get; set; }
        public Guid UpozilaId { get; set; }
        public Guid MouzaId { get; set; }
        public string HoldingNo { get; set; }
    }
}

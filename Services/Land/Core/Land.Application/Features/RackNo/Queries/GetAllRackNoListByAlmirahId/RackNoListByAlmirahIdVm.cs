using System;

namespace Land.Application.Features.RackNo.Queries.GetAllRackNoListByAlmirahId
{
    public class RackNoListByAlmirahIdVm
    {
        public Guid RackNoInfoId { get; set; }
        public int? RackNoInfoName { get; set; }
        public Guid AlmirahNoInfoId { get; set; }
        public int? AlmirahNoInfoName { get; set; }
    }
}

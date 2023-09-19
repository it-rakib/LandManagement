using MediatR;
using System;
using System.Collections.Generic;

namespace Land.Application.Features.RackNo.Queries.GetAllRackNoListByAlmirahId
{
    public class GetAllRackNoListByAlmirahIdQuery : IRequest<List<RackNoListByAlmirahIdVm>>
    {
        public Guid AlmirahNoInfoId { get; set; }
    }
}

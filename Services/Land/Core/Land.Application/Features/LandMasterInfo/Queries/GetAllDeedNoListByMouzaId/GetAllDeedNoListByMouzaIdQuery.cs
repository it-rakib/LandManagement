using System;
using System.Collections.Generic;
using MediatR;

namespace Land.Application.Features.LandMasterInfo.Queries.GetAllDeedNoListByMouzaId
{
    public class GetAllDeedNoListByMouzaIdQuery : IRequest<List<DeedNoListByMouzaIdVm>>
    {
        public Guid MouzaId { get; set; }
    }
}

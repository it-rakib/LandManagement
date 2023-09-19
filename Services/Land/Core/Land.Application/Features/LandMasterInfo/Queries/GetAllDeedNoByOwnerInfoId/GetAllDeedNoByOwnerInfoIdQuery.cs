using MediatR;
using System;
using System.Collections.Generic;

namespace Land.Application.Features.LandMasterInfo.Queries.GetAllDeedNoByOwnerInfoId
{
    public class GetAllDeedNoByOwnerInfoIdQuery : IRequest<List<DeedNoByOwnerInfoIdVm>>
    {
        public Guid OwnerInfoId { get; set; }
    }
}

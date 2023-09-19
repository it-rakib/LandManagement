using MediatR;
using System;
using System.Collections.Generic;

namespace Land.Application.Features.MutationMasterInfo.Queries.GetAllDagNoListByLandMasterKhatianType
{
    public class GetAllDagNoListByLandMasterKhatianTypeQuery : IRequest<List<DagNoListByLandMasterKhatianTypeVm>>
    {
        public Guid LandMasterId { get; set; }
        public Guid KhatianTypeId { get; set; }
    }
}

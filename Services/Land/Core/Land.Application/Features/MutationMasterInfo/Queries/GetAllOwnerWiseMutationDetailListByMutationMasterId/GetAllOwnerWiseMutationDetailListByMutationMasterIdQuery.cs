using System;
using System.Collections.Generic;
using MediatR;

namespace Land.Application.Features.MutationMasterInfo.Queries.GetAllOwnerWiseMutationDetailListByMutationMasterId
{
    public class GetAllOwnerWiseMutationDetailListByMutationMasterIdQuery : IRequest<List<OwnerWiseMutationDetailListByMutationMasterIdVm>>
    {
        public Guid MutationMasterId { get; set; }
    }
}

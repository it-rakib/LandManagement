using System;
using MediatR;


namespace Land.Application.Features.MutationMasterInfo.Queries.GetMutationMasterById
{
    public class GetMutationMasterByIdQuery : IRequest<MutationMasterByIdVm>
    {
        public Guid MutationMasterId { get; set; }
    }
}

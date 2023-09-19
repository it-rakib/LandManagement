using MediatR;
using System;
using System.Collections.Generic;

namespace Land.Application.Features.FileNo.Queries.GetFileNoListByFileCodeId
{
    public class GetFileNoListByFileCodeIdQuery : IRequest<List<FileNoListByFileCodeIdVm>>
    {
        public Guid FileCodeInfoId { get; set; }
    }
}

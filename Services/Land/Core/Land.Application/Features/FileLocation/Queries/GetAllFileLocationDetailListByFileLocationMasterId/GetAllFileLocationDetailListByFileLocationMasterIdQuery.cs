using MediatR;
using System;
using System.Collections.Generic;

namespace Land.Application.Features.FileLocation.Queries.GetAllFileLocationDetailListByFileLocationMasterId
{
    public class GetAllFileLocationDetailListByFileLocationMasterIdQuery : IRequest<List<FileLocationDetailListByFileLocationMasterIdVm>>
    {
        public Guid FileLocationMasterId { get; set; }
    }
}

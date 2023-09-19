using Common.Service.Repositories;
using Land.Application.Features.FileNo.Queries.GetFileNoListByFileCodeId;
using Land.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Land.Application.Contracts.Persistence
{
    public interface IFileNoRepository : IAsyncRepository<FileNoInfo>
    {
        Task<List<FileNoListByFileCodeIdVm>> GetFileNoListByFileCodeId(Guid fileCodeId);
    }
}

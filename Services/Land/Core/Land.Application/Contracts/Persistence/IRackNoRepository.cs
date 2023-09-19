using Common.Service.Repositories;
using Land.Application.Features.RackNo.Queries.GetAllRackNoListByAlmirahId;
using Land.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Land.Application.Contracts.Persistence
{
    public interface IRackNoRepository : IAsyncRepository<RackNoInfo>
    {
        Task<List<RackNoListByAlmirahIdVm>> GetAllRackNoListByAlmirahId(Guid almirahId);
    }
}

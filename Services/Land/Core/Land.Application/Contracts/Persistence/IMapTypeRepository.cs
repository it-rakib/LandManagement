using Common.Service.Repositories;
using Land.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Land.Application.Contracts.Persistence
{
    public interface IMapTypeRepository : IAsyncRepository<MapType>
    {
    }
}

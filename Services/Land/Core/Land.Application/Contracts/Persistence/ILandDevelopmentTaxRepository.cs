using System;
using System.Threading.Tasks;
using Common.Service.CommonEntities.KendoGrid;
using Common.Service.Repositories;
using Land.Application.Features.LandDevelopmentTaxInfo.Queries.GetAllLandDevelopmentTaxGrid;
using Land.Domain.Models;

namespace Land.Application.Contracts.Persistence
{
    public interface ILandDevelopmentTaxRepository : IAsyncRepository<LandDevelopmentTax>
    {
        Task<GridEntity<LandDevelopmentTaxGridVm>> GetAllPagingAsync(GridOptions options);
        Task<LandDevelopmentTax> GetLandDevelopmentTaxById(Guid landDevelopmentTaxId);

        //Task<bool> IsExist(Guid landDevelopmentTaxId, Guid mutationMasterId);
    }
}

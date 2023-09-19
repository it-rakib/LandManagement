using Common.Service.Repositories;
using Land.Application.Contracts;
using Land.Application.Contracts.Persistence;
using Land.Domain.Models;
using Land.Persistence.Repositories;
using Merchandising.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Merchandising.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<LANDDBContext>(options =>
                    options.UseSqlServer(configuration.GetConnectionString("landConnectionString")).EnableSensitiveDataLogging());
            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
            services.AddScoped<ICmnDivisionRepository, CmnDivisionRepository>();
            services.AddScoped<ICmnDistrictRepository, CmnDistrictRepository>();
            services.AddScoped<ICmnUpozilaRepository, CmnUpozilaRepository>();
            services.AddScoped<ICmnMouzaRepository, CmnMouzaRepository>();
            services.AddScoped<ILandOwnerTypeRepository, LandOwnerTypeRepository>();
            services.AddScoped<ILandMasterRepository, LandMasterRepository>();
            services.AddScoped<IKhatiyanTypeRepository, KhatianTypeRepository>();
            services.AddScoped<IOwnerInfoRepository, OwnerInforepository>();
            services.AddScoped<ICmnSubRegOfficeRepository, CmnSubRegOfficeRepository>();
            services.AddScoped<IMutationMasterRepository, MutationMasterRepository>();
            services.AddScoped<ILandDevelopmentTaxRepository, LandDevelopmentTaxRepository>();
            services.AddScoped<ICmnBanglaYearRepository, CmnBanglaYearRepository>();
            services.AddScoped<ILandOwnersDetailRepository, LandOwnersDetailRepository>();
            services.AddScoped<IFileLocationRepository, FileLocationRepository>();
            services.AddScoped<ICmnDocumentRepository, CmnDocumentRepository>();
            services.AddScoped<IFileCodeRepository, FileCodeRepository>();
            services.AddScoped<IFileNoRepository, FileNoRepository>();
            services.AddScoped<IAlmirahNoRepository, AlmirahNoRepository>();
            services.AddScoped<IRackNoRepository, RackNoRepository>();
            services.AddScoped<ISheetNoInfoRepository, SheetNoInfoRepository>();
            services.AddScoped<ILandMapRepository, LandMapRepository>();
            services.AddScoped<IMapTypeRepository, MapTypeRepository>();
            services.AddScoped<IDapperRepository, DapperRepository>();
            return services;
        }
    }
}

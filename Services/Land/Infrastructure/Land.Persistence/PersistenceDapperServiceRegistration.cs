using Land.Application.Contracts.Persistence;
using Land.Domain.Models;
using Land.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Merchandising.Persistence
{
    public static class PersistenceDapperServiceRegistration
    {
        public static IServiceCollection AddPersistenceDapperServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<LANDDBContext>(options =>
                  options.UseSqlServer(configuration.GetConnectionString("landConnectionString")));
            services.AddScoped<IDapperRepository, DapperRepository>();

            return services;
        }
    }
}

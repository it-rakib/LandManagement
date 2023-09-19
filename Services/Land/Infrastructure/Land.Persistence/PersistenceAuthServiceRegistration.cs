using Common.Service.Repositories;
using Merchandising.Application.Contracts.Persistence.AuthPersistence;
using Merchandising.Domain.AuthModels;
using Merchandising.Persistence.BaseRepositories;
using Merchandising.Persistence.Repositories.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Merchandising.Persistence
{
    public static class PersistenceAuthServiceRegistration
    {
        public static IServiceCollection AddAuthPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            //Auth DB Context
            services.AddDbContext<ERPUSERDBContext>(options =>
                   options.UseSqlServer(configuration.GetConnectionString("authConnectionsString")));

            services.AddScoped(typeof(IAsyncAuthRepository<>), typeof(AuthBaseRepository<>));

            services.AddScoped<IUserInfoRepository, UserInfoRepository>();

            return services;
        }
    }
}

using Common.Service.Repositories;
using Merchandising.Application.Contracts.Persistence.HrmsPersistence;
using Merchandising.Domain.HrmsModels;
using Merchandising.Persistence.BaseRepositories;
using Merchandising.Persistence.Repositories.Hrms;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Merchandising.Persistence
{
    public static class PersistenceHrmsServiceRegistration
    {
        public static IServiceCollection AddHrmsPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            //HRMS DB Context
            services.AddDbContext<CoreERPContext>(options =>
                   options.UseSqlServer(configuration.GetConnectionString("hrmsConnectionsString")));

            services.AddScoped(typeof(IAsyncHrmsRepository<>), typeof(HrmsBaseRepository<>));

            services.AddScoped<ICommonCompanyRepository, CommonCompanyRepository>();
            services.AddScoped<IOgranogram_ApplicationsApprovalRepository, Ogranogram_ApplicationsApprovalRepository>();
            services.AddScoped<IAttendancePunchRecordRepository, AttendancePunchRecordRepository>();

            return services;
        }
    }
}

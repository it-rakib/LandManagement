using Merchandising.Application.Contracts.Infrastructure.File;
using Merchandising.Application.Contracts.Infrastructure.Mail;
using Merchandising.Application.Models;
using Merchandising.Infrastructure.FileHalper;
using Merchandising.Infrastructure.Mail;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Merchandising.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));

            services.AddScoped<IEmailService, EmailService>();
            services.AddTransient<IFileService, FileService>();
            return services;
        }
    }
}

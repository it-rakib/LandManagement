using Merchandising.Application.Models;
using System.Threading.Tasks;

namespace Merchandising.Application.Contracts.Infrastructure.Mail
{
    public interface IEmailService
    {
        
        Task SendEmailAsync(Email email, EmailSettings emailSettings, string fileNameWithPath);  
    }
}

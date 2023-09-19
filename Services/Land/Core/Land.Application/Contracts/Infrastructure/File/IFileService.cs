using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Merchandising.Application.Contracts.Infrastructure.File
{
    public interface IFileService
    {
        Task<string> UploadFile(IFormFile formFile, string ID);
        Task DeleteFile(string companyID, string fileName);
    }
}

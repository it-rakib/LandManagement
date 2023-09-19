using Merchandising.Application.Contracts.Infrastructure.File;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Merchandising.Infrastructure.FileHalper
{
    public class FileService : IFileService
    {
        public async Task DeleteFile(string companyID, string fileName)
        {
            var fileLocation = Path.Combine(Directory.GetCurrentDirectory(), "All-Documents", companyID, fileName);
            FileInfo file = new FileInfo(fileLocation);
            if (file.Exists)
            {
                System.IO.File.Delete(fileLocation);
                file.Delete();
            }
        }

        public async Task<string> UploadFile(IFormFile formFile, string ID)
        {
            try
            {
                if (formFile != null && formFile.Length > 0)
                {
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "All-Documents", ID);
                    if (!Directory.Exists(filePath))
                    {
                        Directory.CreateDirectory(filePath);
                    }
                    var fileLocation = Path.Combine(filePath, formFile.FileName);
                    using (var stream = new FileStream(fileLocation, FileMode.Create))
                    {
                        await formFile.CopyToAsync(stream);
                    }
                    return fileLocation;
                }
                else
                {
                    return "File Upload Failed";
                }
            }
            catch (Exception ex)
            {

                return ex.Message.ToString();
            }


        }
    }
}

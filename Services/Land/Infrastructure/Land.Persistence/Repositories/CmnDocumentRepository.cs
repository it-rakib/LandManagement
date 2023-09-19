using Common.Service.CommonEntities.KendoGrid;
using Land.Application.Contracts.Persistence;
using Land.Application.Features.CmnDocument;
using Land.Domain.Models;
using Merchandising.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Land.Persistence.Repositories
{
    public class CmnDocumentRepository : BaseRepository<CmnDocumentFile>, ICmnDocumentRepository
    {
        public CmnDocumentRepository(LANDDBContext dbContext) : base(dbContext)
        {
        }

        public Task<List<CmnDocumentFile>> GetAllDocumentListAsync()
        {
            throw new NotImplementedException();
        }

        public Task<GridEntity<CmnDocumentFile>> GetAllDocumentListPagingAsync(GridOptions options)
        {
            throw new NotImplementedException();
        }

        public CmnDocumentFile GetDocumentFileInfo(string documentFileFileUniqueName)
        {
            return _dbContext.CmnDocumentFiles
                .FirstOrDefault(d => d.FileUniqueName == documentFileFileUniqueName);
        }

        public void AddRemoveDocument(DocumentVM cmnDocumentFile)
        {
            var documentFile = new CmnDocumentFile()
            {
                // DocumentId = request.DocumentId,
                FileName = cmnDocumentFile.FileName,
                ModuleName = cmnDocumentFile.ModuleName,
                ModuleMasterId = cmnDocumentFile.ModuleMasterId,
                FileSize = cmnDocumentFile.FileSize,
                FileExtension = cmnDocumentFile.FileExtension,
                FileUniqueName = cmnDocumentFile.FileUniqueName
            };
            if (cmnDocumentFile.ActionType == "Save")
            {
                // _documentRepository.AddAsync(documentFile);
                _dbContext.Add(documentFile);
                _dbContext.SaveChanges();

            }
            if (cmnDocumentFile.ActionType == "Remove")
            {
                var model = GetDocumentFileInfo(documentFile.FileUniqueName);
                //_documentRepository.DeleteAsync(model);
                _dbContext.Entry(model).State = EntityState.Deleted;
                _dbContext.SaveChanges();

            }
        }
    }
}

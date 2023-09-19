using Common.Service.CommonEntities.KendoGrid;
using Common.Service.Repositories;
using Land.Application.Features.CmnDocument;
using Land.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Land.Application.Contracts.Persistence
{
    public interface ICmnDocumentRepository : IAsyncRepository<CmnDocumentFile>
    {
        Task<List<CmnDocumentFile>> GetAllDocumentListAsync();
        Task<GridEntity<CmnDocumentFile>> GetAllDocumentListPagingAsync(GridOptions options);

        CmnDocumentFile GetDocumentFileInfo(string documentFileFileUniqueName);
        void AddRemoveDocument(DocumentVM cmnDocumentFile);
    }
}

using Common.Service.Repositories;
using Merchandising.Application.Features.HrmsFeatures.Queries.GetIsCSForward;
using Merchandising.Application.Features.HrmsFeatures.Queries.GetSupervisorByEmpId;
using Merchandising.Domain.HrmsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merchandising.Application.Contracts.Persistence.HrmsPersistence
{
    public interface IOgranogram_ApplicationsApprovalRepository:IAsyncRepository<OgranogramApplicationsApproval>
    {
        Task<GetIsCSForwardResponse> IsCSForward(long empId);
        Task<GetSupervisorByEmpIdResponse> GetSupervisorByEmpId(long empId);
        Task<bool> ChkIsCSForward(long empId);
    }
}

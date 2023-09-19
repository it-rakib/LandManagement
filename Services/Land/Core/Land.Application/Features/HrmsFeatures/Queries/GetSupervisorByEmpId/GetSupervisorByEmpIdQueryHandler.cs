using MediatR;
using Merchandising.Application.Contracts.Persistence.HrmsPersistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Merchandising.Application.Features.HrmsFeatures.Queries.GetSupervisorByEmpId
{
    public class GetSupervisorByEmpIdQueryHandler : IRequestHandler<GetSupervisorByEmpIdQuery, GetSupervisorByEmpIdResponse>
    {
        private readonly IOgranogram_ApplicationsApprovalRepository _repository;

        public GetSupervisorByEmpIdQueryHandler(IOgranogram_ApplicationsApprovalRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<GetSupervisorByEmpIdResponse> Handle(GetSupervisorByEmpIdQuery request, CancellationToken cancellationToken)
        {
            GetSupervisorByEmpIdResponse response = new();
            try
            {
                var validator = new GetSupervisorByEmpIdQueryValidator();
                var validationResult = await validator.ValidateAsync(request);
                if (validationResult.Errors.Count > 0)
                {
                    response.Success = false;
                    response.ValidationErrors = new List<string>();
                    foreach (var error in validationResult.Errors)
                    {
                        response.Message = response.Message + Environment.NewLine + error.ErrorMessage;
                        response.ValidationErrors.Add(error.ErrorMessage);
                    }
                }
                if (response.Success == true)
                {
                    response = await _repository.GetSupervisorByEmpId(request.EmpID);
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.InnerException == null ? ex.Message : ex.InnerException.Message;
            }
            return response;
        }
    }
}

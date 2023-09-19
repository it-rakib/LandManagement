using FluentValidation;

namespace Merchandising.Application.Features.HrmsFeatures.Queries.GetSupervisorByEmpId
{
    public class GetSupervisorByEmpIdQueryValidator : AbstractValidator<GetSupervisorByEmpIdQuery>
    {
        public GetSupervisorByEmpIdQueryValidator()
        {
            RuleFor(r => r.EmpID)
                .NotEmpty().WithMessage("{PropertyName} cannot be Empty!")
                .NotNull().WithMessage("{PropertyName} cannot be Null!");
        }
    }
}

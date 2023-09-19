using FluentValidation;

namespace Merchandising.Application.Features.HrmsFeatures.Queries.GetIsCSForward
{
    public class GetIsCSForwardQueryValidator : AbstractValidator<GetIsCSForwardQuery>
    {
        public GetIsCSForwardQueryValidator()
        {
            RuleFor(r => r.EmpId)
                .NotEmpty().WithMessage("{PropertyName} cannot be Empty!")
                .NotNull().WithMessage("{PropertyName} cannot be Null!");
        }
    }
}

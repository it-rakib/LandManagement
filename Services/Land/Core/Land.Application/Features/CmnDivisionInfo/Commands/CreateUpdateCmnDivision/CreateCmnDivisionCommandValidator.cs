using FluentValidation;
using Land.Application.Contracts.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Land.Application.Features.CmnDivisionInfo.Commands.CreateUpdateCmnDivision
{
    public class CreateCmnDivisionCommandValidator : AbstractValidator<CreateCmnDivisionCommand>
    {
        private readonly ICmnDivisionRepository _cmnDivisionRepository;

        public CreateCmnDivisionCommandValidator(ICmnDivisionRepository cmnDivisionRepository)
        {
            _cmnDivisionRepository = cmnDivisionRepository ?? throw new ArgumentNullException(nameof(cmnDivisionRepository));

            RuleFor(p => p.DivisionName)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .NotNull()
               .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");
            RuleFor(a => a)
                .MustAsync(DivisionNameUnique)
                .WithMessage("A Division with the same name already exists");
        }

        private async Task<bool> DivisionNameUnique(CreateCmnDivisionCommand e, CancellationToken token)
        {
            try
            {
                return !(await _cmnDivisionRepository.IsDivisionNameUnique(e.DivisionId, e.DivisionName));
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }

        }
    }
}

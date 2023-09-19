using FluentValidation;
using Land.Application.Contracts.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Land.Application.Features.CmnSubRegOfficeInfo.Commands.CreateUpdateCmnSubRegOffice
{
    public class CreateCmnSubRegOfficeCommandValidator : AbstractValidator<CreateCmnSubRegOfficeCommand>
    {
        private readonly ICmnSubRegOfficeRepository _cmnSubRegOfficeRepository;

        public CreateCmnSubRegOfficeCommandValidator(ICmnSubRegOfficeRepository cmnSubRegOfficeRepository)
        {
            _cmnSubRegOfficeRepository = cmnSubRegOfficeRepository ?? throw new ArgumentNullException(nameof(cmnSubRegOfficeRepository));

            RuleFor(p => p.SubRegOfficeName)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .NotNull()
               .MaximumLength(150).WithMessage("{PropertyName} must not exceed 150 characters.");
            RuleFor(a => a)
                .MustAsync(SubRegOfficeNameUnique)
                .WithMessage("A Sub-Register Office with the same name already exists");
        }

        private async Task<bool> SubRegOfficeNameUnique(CreateCmnSubRegOfficeCommand e, CancellationToken token)
        {
            try
            {
                return !(await _cmnSubRegOfficeRepository.IsSubRegOfficeNameUnique(e.SubRegOfficeId, e.SubRegOfficeName));
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }

        }
    }
}

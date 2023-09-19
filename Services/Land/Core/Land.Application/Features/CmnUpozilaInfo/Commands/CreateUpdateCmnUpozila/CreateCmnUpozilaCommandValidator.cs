using FluentValidation;
using Land.Application.Contracts.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Land.Application.Features.CmnUpozilaInfo.Commands.CreateUpdateCmnUpozila
{
    public class CreateCmnUpozilaCommandValidator : AbstractValidator<CreateCmnUpozilaCommand>
    {
        private readonly ICmnUpozilaRepository _cmnUpozilaRepository;

        public CreateCmnUpozilaCommandValidator(ICmnUpozilaRepository cmnUpozilaRepository)
        {
            _cmnUpozilaRepository = cmnUpozilaRepository ?? throw new ArgumentNullException(nameof(cmnUpozilaRepository));
            
            RuleFor(p => p.UpozilaName)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .NotNull()
               .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");
            RuleFor(a => a)
                .MustAsync(UpozilaNameUnique)
                .WithMessage("A Upozila with the same name already exists");
        }

        private async Task<bool> UpozilaNameUnique(CreateCmnUpozilaCommand e, CancellationToken token)
        {
            try
            {
                return !(await _cmnUpozilaRepository.IsUpozilaNameUnique(e.UpozilaId, e.UpozilaName));
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }

        }
    }
}

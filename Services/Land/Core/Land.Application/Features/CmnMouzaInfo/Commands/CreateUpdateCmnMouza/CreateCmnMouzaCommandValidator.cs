using FluentValidation;
using Land.Application.Contracts.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Land.Application.Features.CmnMouzaInfo.Commands.CreateUpdateCmnMouza
{
    public class CreateCmnMouzaCommandValidator : AbstractValidator<CreateCmnMouzaCommand>
    {
        private readonly ICmnMouzaRepository _cmnMouzaRepository;

        public CreateCmnMouzaCommandValidator(ICmnMouzaRepository cmnMouzaRepository)
        {
            _cmnMouzaRepository = cmnMouzaRepository ?? throw new ArgumentNullException(nameof(cmnMouzaRepository));

            RuleFor(p => p.MouzaName)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .NotNull()
               .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");
            RuleFor(a => a)
                .MustAsync(MouzaNameUnique)
                .WithMessage("A Mouza with the same name already exists");
        }

        private async Task<bool> MouzaNameUnique(CreateCmnMouzaCommand e, CancellationToken token)
        {
            try
            {
                return !(await _cmnMouzaRepository.IsMouzaNameUnique(e.MouzaId, e.MouzaName));
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }

        }
    }
}

using FluentValidation;
using Land.Application.Contracts.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Land.Application.Features.FileCode.Commands.CreateUpdateFileCode
{
    public class CreateUpdateFileCodeCommandValidator : AbstractValidator<CreateUpdateFileCodeCommand>
    {
        private readonly IFileCodeRepository _fileCodeRepository;

        public CreateUpdateFileCodeCommandValidator(IFileCodeRepository fileCodeRepository)
        {
            _fileCodeRepository = fileCodeRepository ?? throw new ArgumentNullException(nameof(fileCodeRepository));

            RuleFor(p => p.FileCodeInfoName)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .NotNull()
               .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");
            RuleFor(a => a)
                .MustAsync(FileCodeInfoNameNameUnique)
                .WithMessage("A File Code with the same name already exists");
        }
        private async Task<bool> FileCodeInfoNameNameUnique(CreateUpdateFileCodeCommand e, CancellationToken token)
        {
            try
            {
                return !(await _fileCodeRepository.IsFileCodeNameUnique(e.FileCodeInfoId, e.FileCodeInfoName));
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }

        }
    }
}

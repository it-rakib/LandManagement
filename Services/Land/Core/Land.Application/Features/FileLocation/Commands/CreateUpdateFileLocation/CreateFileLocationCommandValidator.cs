using FluentValidation;
using Land.Application.Contracts.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Land.Application.Features.FileLocation.Commands.CreateUpdateFileLocation
{
    public class CreateFileLocationCommandValidator : AbstractValidator<CreateFileLocationCommand>
    {
        private readonly IFileLocationRepository _fileLocationRepository;

        public CreateFileLocationCommandValidator(IFileLocationRepository fileLocationRepository)
        {
            _fileLocationRepository = fileLocationRepository ?? throw new ArgumentNullException(nameof(fileLocationRepository));

            RuleFor(p => p.FileNoInfoId)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .NotNull()
               .WithMessage("{PropertyName} must not null");
            RuleFor(p => p.RackNoInfoId)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .NotNull()
               .WithMessage("{PropertyName} must not null");
            RuleFor(a => a)
                .MustAsync(FileNoUnique)
                .WithMessage("This File number is already exists");
        }

        private async Task<bool> FileNoUnique(CreateFileLocationCommand e, CancellationToken token)
        {
            try
            {
                return !(await _fileLocationRepository.IsFileNoUnique(e.FileLocationMasterId, e.FileNoInfoId));
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }

        }

    }
}

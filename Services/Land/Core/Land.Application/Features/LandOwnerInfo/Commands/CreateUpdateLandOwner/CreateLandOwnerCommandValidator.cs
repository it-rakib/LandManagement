using FluentValidation;
using Land.Application.Contracts.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Land.Application.Features.LandOwnerInfo.Commands.CreateUpdateLandOwner
{
    public class CreateLandOwnerCommandValidator : AbstractValidator<CreateLandOwnerCommand>
    {
        private readonly IOwnerInfoRepository _ownerInfoRepository;

        public CreateLandOwnerCommandValidator(IOwnerInfoRepository ownerInfoRepository)
        {
            _ownerInfoRepository = ownerInfoRepository ?? throw new ArgumentNullException(nameof(ownerInfoRepository));

            RuleFor(p => p.OwnerInfoName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");
            RuleFor(a => a)
                .MustAsync(OwnerInfoNameUnique)
                .WithMessage("A Owner with the same name is already exists");
        }

        private async Task<bool> OwnerInfoNameUnique(CreateLandOwnerCommand e, CancellationToken token)
        {
            try
            {
                return !(await _ownerInfoRepository.IsOwnerNameUnique(e.OwnerInfoId, e.OwnerInfoName));
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }
    }
}

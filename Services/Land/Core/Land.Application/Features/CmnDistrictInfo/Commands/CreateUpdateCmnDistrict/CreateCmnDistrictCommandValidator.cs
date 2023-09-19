using FluentValidation;
using Land.Application.Contracts.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Land.Application.Features.CmnDistrictInfo.Commands.CreateUpdateCmnDistrict
{
    public class CreateCmnDistrictCommandValidator : AbstractValidator<CreateCmnDistrictCommand>
    {
        private readonly ICmnDistrictRepository _cmnDistrictRepository;

        public CreateCmnDistrictCommandValidator(ICmnDistrictRepository cmnDistrictRepository)
        {
            _cmnDistrictRepository = cmnDistrictRepository ?? throw new ArgumentNullException(nameof(cmnDistrictRepository));

            RuleFor(p => p.DistrictName)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .NotNull()
               .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");
            RuleFor(a => a)
                .MustAsync(DistrictNameUnique)
                .WithMessage("A District with the same name already exists");
        }

        private async Task<bool> DistrictNameUnique(CreateCmnDistrictCommand e, CancellationToken token)
        {
            try
            {
                return !(await _cmnDistrictRepository.IsDistrictNameUnique(e.DistrictId, e.DistrictName));
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }

        }
    }
}

using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Land.Application.Contracts.Persistence;

namespace Land.Application.Features.MutationMasterInfo.Commands.CreateOrUpdateMutationMaster
{
    public class CreateOrUpdateMutationMasterCommandValidator : AbstractValidator<CreateOrUpdateMutationMasterCommand>
    {
        private readonly IMutationMasterRepository _mutationMasterRepository;

        public CreateOrUpdateMutationMasterCommandValidator(IMutationMasterRepository mutationMasterRepository)
        {
            _mutationMasterRepository = mutationMasterRepository ??throw new ArgumentNullException(nameof(mutationMasterRepository));
            RuleFor(p => p.DivisionId)
                .NotEmpty().WithMessage("{PropertyName} is required!")
                .NotNull();
            RuleFor(p => p.DistrictId)
                .NotEmpty().WithMessage("{PropertyName} is required!")
                .NotNull();
            RuleFor(p => p.UpozilaId)
                .NotEmpty().WithMessage("{PropertyName} is required!")
                .NotNull();
            RuleFor(p => p.MouzaId)
                .NotEmpty().WithMessage("{PropertyName} is required!")
                .NotNull();
            RuleFor(a => a)
                .MustAsync(UniqueHoldingNo)
                .WithMessage("Holding No Already Exist!"); 
        }

        private async Task<bool> UniqueHoldingNo(CreateOrUpdateMutationMasterCommand e, CancellationToken token)
        {
            try
            {
                return !(await _mutationMasterRepository.IsExist(e.MutationMasterId, e.HoldingNo));
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
        }
    }
}

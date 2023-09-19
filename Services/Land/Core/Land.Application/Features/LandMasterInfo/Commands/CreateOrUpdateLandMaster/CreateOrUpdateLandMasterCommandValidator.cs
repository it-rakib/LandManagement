using FluentValidation;
using Land.Application.Contracts.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Land.Application.Features.LandMasterInfo.Commands.CreateOrUpdateLandMaster
{
    public class CreateOrUpdateLandMasterCommandValidator : AbstractValidator<CreateOrUpdateLandMasterCommand>
    {
        private readonly ILandMasterRepository _landMasterRepository;

        public CreateOrUpdateLandMasterCommandValidator(ILandMasterRepository landMasterRepository)
        {
            _landMasterRepository = landMasterRepository ?? throw new ArgumentNullException(nameof(landMasterRepository));
            RuleFor(p => p.DivisionId)
                  .NotEmpty().WithMessage("{PropertyName} is required!")
                  .NotNull();
            RuleFor(p => p.DistrictId)
                  .NotEmpty().WithMessage("{PropertyName} is required!")
                  .NotNull();
            RuleFor(p => p.UpozilaId)
                  .NotEmpty().WithMessage("{PropertyName} is required!")
                  .NotNull();
            //RuleFor(a => a)
            //    .MustAsync(UniqueLand)
            //    .WithMessage("Land Already Exist!");
            RuleFor(b => b)
                .MustAsync(UniqueDeed)
                .WithMessage("Deed Already Exist in this sub-register office in the same year!");
        }

        //private async Task<bool> UniqueLand(CreateOrUpdateLandMasterCommand e, CancellationToken token)
        //{
        //    try
        //    {
        //        return !(await _landMasterRepository.IsExist(e.DeedNo));
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex.InnerException;
        //    }
        //}

        private async Task<bool> UniqueDeed(CreateOrUpdateLandMasterCommand e, CancellationToken token)
        {
            try
            {
                if (e.LandMasterId == Guid.Empty)
                {
                    return !(await _landMasterRepository.IsDeedExist(e.SubRegOfficeId, e.DeedNo, e.EntryDate));

                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
        }
    }
}

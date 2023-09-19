using FluentValidation;
using Land.Application.Contracts.Persistence;
using Land.Application.Features.LandMasterInfo.Commands.CreateOrUpdateLandMaster;
using System;
using System.Threading.Tasks;
using System.Threading;

namespace Land.Application.Features.LandMapInfo.Command.CreateUpdateLandMap
{
    public class CreateUpdateLandMapCommandValidator : AbstractValidator<CreateUpdateLandMapCommand>
    {
        private readonly ILandMapRepository _landMapRepository;

        public CreateUpdateLandMapCommandValidator(ILandMapRepository landMapRepository)
        {
            _landMapRepository = landMapRepository ?? throw new ArgumentNullException(nameof(landMapRepository));
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
            RuleFor(p => p.MapTypeId)
                .NotEmpty().WithMessage("{PropertyName} is required!")
                .NotNull();
            //RuleFor(b=>b)
            //    .MustAsync(UniqueMap)
            //    .WithMessage("MAP Already Exist!");

        }
        //private async Task<bool> UniqueMap(CreateUpdateLandMapCommand e, CancellationToken token)
        //{
        //    try
        //    {
        //        if (e.LandMapId != Guid.Empty)
        //        {
        //            return !(await _landMapRepository.IsMapExist(e.LandMapId));

        //        }
        //        else
        //        {
        //            return true;
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex.InnerException;
        //    }
        //}
    }
}

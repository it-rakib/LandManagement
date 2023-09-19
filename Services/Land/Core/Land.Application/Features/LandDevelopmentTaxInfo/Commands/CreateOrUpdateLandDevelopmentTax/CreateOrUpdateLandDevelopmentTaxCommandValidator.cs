using System;
using FluentValidation;
using Land.Application.Contracts.Persistence;

namespace Land.Application.Features.LandDevelopmentTaxInfo.Commands.CreateOrUpdateLandDevelopmentTax
{
    public class CreateOrUpdateLandDevelopmentTaxCommandValidator : AbstractValidator<CreateOrUpdateLandDevelopmentTaxCommand>
    {
        private readonly ILandDevelopmentTaxRepository _developmentTaxRepository;

        public CreateOrUpdateLandDevelopmentTaxCommandValidator(ILandDevelopmentTaxRepository developmentTaxRepository)
        {
            _developmentTaxRepository = developmentTaxRepository ?? throw new ArgumentNullException(nameof(developmentTaxRepository));
            //RuleFor(p => p.DivisionId)
            //    .NotEmpty().WithMessage("{PropertyName} is required!")
            //    .NotNull();
            //RuleFor(p => p.DistrictId)
            //    .NotEmpty().WithMessage("{PropertyName} is required!")
            //    .NotNull();
            //RuleFor(p => p.UpozilaId)
            //    .NotEmpty().WithMessage("{PropertyName} is required!")
            //    .NotNull();
            //RuleFor(p => p.MouzaId)
            //    .NotEmpty().WithMessage("{PropertyName} is required!")
            //    .NotNull();
        }
    }
}

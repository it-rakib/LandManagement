using FluentValidation;
using Land.Application.Contracts.Persistence;
using System;

namespace Land.Application.Features.CmnDocument.Commands.CreateUpdateDocumentCommand
{
    public class CreateOrUpdateCmnDocumentCommandValidator : AbstractValidator<CreateOrUpdateCmnDocumentCommand>
    {
        private readonly ICmnDocumentRepository _cmnDocument;

        public CreateOrUpdateCmnDocumentCommandValidator(ICmnDocumentRepository cmnDocumentRepository)
        {
            _cmnDocument = cmnDocumentRepository ?? throw new ArgumentNullException(nameof(cmnDocumentRepository));
            RuleFor(p => p.FileUniqueName)
                  .NotEmpty().WithMessage("{PropertyName} is required.")
                  .NotNull();

        }

        //private async Task<bool> BankNameUnique(CreateOrUpdateCmnDocumentCommand e, CancellationToken token)
        //{
        //    try
        //    {
        //        return !(true);
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex.InnerException;
        //    }
        //}
    }
}

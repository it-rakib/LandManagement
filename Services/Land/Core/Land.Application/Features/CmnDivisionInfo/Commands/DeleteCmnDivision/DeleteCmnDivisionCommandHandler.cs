using Common.Service.Repositories;
using Land.Domain.Models;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Land.Application.Features.CmnDivisionInfo.Commands.DeleteCmnDivision
{
    public class DeleteCmnDivisionCommandHandler : IRequestHandler<DeleteCmnDivisionCommand>
    {
        private readonly IAsyncRepository<CmnDivision> _cmnDivisionRepository;

        public DeleteCmnDivisionCommandHandler(IAsyncRepository<CmnDivision> cmnDivisionRepository)
        {
            _cmnDivisionRepository = cmnDivisionRepository ?? throw new ArgumentNullException(nameof(cmnDivisionRepository));
        }

        public async Task<Unit> Handle(DeleteCmnDivisionCommand request, CancellationToken cancellationToken)
        {
            var cmnDivisionToDelete = await _cmnDivisionRepository.GetByIdAsync(request.DivisionId);
            await _cmnDivisionRepository.DeleteAsync(cmnDivisionToDelete);
            return Unit.Value;
        }
    }
}

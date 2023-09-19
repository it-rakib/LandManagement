using Common.Service.Repositories;
using Land.Domain.Models;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Land.Application.Features.LandOwnerInfo.Commands.DeleteLandOwner
{
    public class DeleteLandOwnerCommandHandler : IRequestHandler<DeleteLandOwnerCommand>
    {
        private readonly IAsyncRepository<OwnerInfo> _ownerInfoRepository;

        public DeleteLandOwnerCommandHandler(IAsyncRepository<OwnerInfo> ownerInfoRepository)
        {
            _ownerInfoRepository = ownerInfoRepository ?? throw new ArgumentNullException(nameof(ownerInfoRepository));
        }

        public async Task<Unit> Handle(DeleteLandOwnerCommand request, CancellationToken cancellationToken)
        {
            var ownerToDelete = await _ownerInfoRepository.GetByIdAsync(request.OwnerInfoId);
            await _ownerInfoRepository.DeleteAsync(ownerToDelete);
            return Unit.Value;
        }
    }
}

using Common.Service.Repositories;
using Land.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Land.Application.Features.CmnDistrictInfo.Commands.DeleteCmnDistrict
{
    public class DeleteCmnDistrictCommandHandler : IRequestHandler<DeleteCmnDistrictCommand>
    {
        private readonly IAsyncRepository<CmnDistrict> _cmnDistrictRepository;

        public DeleteCmnDistrictCommandHandler(IAsyncRepository<CmnDistrict> cmnDistrictRepository)
        {
            _cmnDistrictRepository = cmnDistrictRepository ?? throw new ArgumentNullException(nameof(cmnDistrictRepository));
        }

        public async Task<Unit> Handle(DeleteCmnDistrictCommand request, CancellationToken cancellationToken)
        {
            var cmnDistrictToDelete = await _cmnDistrictRepository.GetByIdAsync(request.DistrictId);
            await _cmnDistrictRepository.DeleteAsync(cmnDistrictToDelete);
            return Unit.Value;
        }
    }
}

using System;
using System.Threading;
using System.Threading.Tasks;
using Land.Application.Contracts.Persistence;
using MediatR;

namespace Land.Application.Features.LandMasterInfo.Queries.GetTotalMouza
{
    public class GetTotalMouzaQueryHandler : IRequestHandler<GetTotalMouzaQuery, int>
    {
        private readonly ILandMasterRepository _landMasterRepository;

        public GetTotalMouzaQueryHandler(ILandMasterRepository landMasterRepository)
        {
            _landMasterRepository = landMasterRepository ?? throw new ArgumentNullException(nameof(landMasterRepository));
        }

        public Task<int> Handle(GetTotalMouzaQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return _landMasterRepository.GetTotalMouza();
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }
    }
}

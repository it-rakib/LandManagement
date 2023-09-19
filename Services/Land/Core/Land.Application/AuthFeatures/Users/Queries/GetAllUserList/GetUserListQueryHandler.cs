using AutoMapper;
using Common.Service.CommonEntities.KendoGrid;
using MediatR;
using Merchandising.Application.Contracts.Persistence.AuthPersistence;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Merchandising.Application.AuthFeatures.Users.Queries.GetAllUserList
{
    public class GetUserListQueryHandler : IRequestHandler<GetUserListQuery, GridEntity<UserListVm>>
    {
        private readonly IUserInfoRepository _userAuthRepository;
        public GetUserListQueryHandler(IUserInfoRepository userAuthRepository, IMapper mapper)
        {
            _userAuthRepository = userAuthRepository ?? throw new ArgumentNullException(nameof(userAuthRepository));
        }

        public async Task<GridEntity<UserListVm>> Handle(GetUserListQuery request, CancellationToken cancellationToken)
        {
            var sourceList = (await _userAuthRepository.GetAllPagingAsync(request.options));

            return sourceList;

        }
    }
}

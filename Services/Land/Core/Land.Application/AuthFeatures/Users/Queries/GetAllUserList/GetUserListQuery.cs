using Common.Service.CommonEntities.KendoGrid;
using MediatR;

namespace Merchandising.Application.AuthFeatures.Users.Queries.GetAllUserList
{
    public class GetUserListQuery : IRequest<GridEntity<UserListVm>>
    {
        public GridOptions options { get; set; }
    }
}

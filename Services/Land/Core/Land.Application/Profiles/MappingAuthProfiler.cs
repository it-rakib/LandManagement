using AutoMapper;
using Merchandising.Application.AuthFeatures.Users.Queries.GetAllUserList;
using Merchandising.Domain.AuthModels;

namespace Merchandising.Application.Profiles
{
    public class MappingAuthProfiler: Profile
    {
        public MappingAuthProfiler()
        {
            CreateMap<UserInfo, UserListVm>().ReverseMap();
        }
    }
}

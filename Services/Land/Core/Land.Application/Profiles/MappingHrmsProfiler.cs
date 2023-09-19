using AutoMapper;
using Merchandising.Application.Features.HrmsFeatures.CommonCompanyInfo.Queries.GetAllCommonCompanyList;
using Merchandising.Application.Features.HrmsFeatures.CommonCompanyInfo.Queries.GetCompanyNameById;
using Merchandising.Domain.HrmsModels;

namespace Merchandising.Application.Profiles
{
    public class MappingHrmsProfiler: Profile
    {
        public MappingHrmsProfiler()
        {
            CreateMap<CommonCompany, CommonCompanyListVm>().ReverseMap();
            CreateMap<CommonCompany, CompanyNameByIdVm>().ReverseMap();
        }
    }
}

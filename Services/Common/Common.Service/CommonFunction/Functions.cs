using System.Collections.Generic;
using System.Linq;

namespace Common.Service.CommonFunction
{
    public class Functions
    {
        public static string GetCompanyName(List<CompanyNameByIdVm> companies, int? id)
        {
            return companies.FirstOrDefault(f => f.CompanyId == id).CompanyName.ToString();
        }
        public static string GetUserName(List<UserNameByIdVm> userInfos, long? userId)
        {
            return userInfos.Where(f => f.UserId == userId).FirstOrDefault().UserName;
        }
    }
}

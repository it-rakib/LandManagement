namespace Common.Service.CommonFunction
{
    public class CompanyNameByIdVm
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
    }
    public class UserNameByIdVm
    {
        public long UserId { get; set; }
        public string EmpCode { get; set; }
        public int? EmpId { get; set; }
        public string UserName { get; set; }
    }
}
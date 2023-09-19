using System;

namespace Merchandising.Application.AuthFeatures.Users.Queries.GetAllUserList
{
    public class UserListVm
    {
        public long UserId { get; set; }

        public string EmpId { get; set; }

        public int? EmpNo { get; set; }

        public string UserName { get; set; }

        public string UsrPass { get; set; }

        public int? UserType { get; set; }

        public int? CompanyId { get; set; }

        public int? UnitId { get; set; }

        public int? DepartmentId { get; set; }

        public int? DesignationId { get; set; }

        public string UsrDesig { get; set; }

        public string PhoneNo { get; set; }

        public string Email { get; set; }

        public DateTime? LastLoginDate { get; set; }

        public int? InvalidLoginTry { get; set; }

        public bool? IsLocked { get; set; }

        public int? UserLevelId { get; set; }

        public bool? IsITAdmin { get; set; }

        public string IsActive { get; set; }  

        public DateTime? RowDate { get; set; }

        public bool? HRMIS_User { get; set; }

        public bool? Merchandising_User { get; set; }

        public bool? IsSetPass { get; set; }
    }
}

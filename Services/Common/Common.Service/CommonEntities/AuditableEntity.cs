using System;

namespace Common.Service.CommonEntities
{
    public class AuditableEntity
    {
        public string CreateBy { get; set; }  
        public DateTime CreateAt { get; set; }  
        public string LastModifiedBy { get; set; }
        public string LastModifiedAt { get; set; }
        
    }
}

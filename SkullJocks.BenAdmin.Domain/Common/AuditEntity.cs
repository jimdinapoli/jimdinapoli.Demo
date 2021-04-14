using System;

namespace SkullJocks.BenAdmin.Domain.Common
{
    public class AuditEntity
    {
        public Guid CreatedBy { get; set; }
        public DateTime CreateDate { get; set; }
        public Guid? LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
    }
}

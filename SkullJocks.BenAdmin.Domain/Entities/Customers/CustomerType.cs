using SkullJocks.BenAdmin.Domain.Common;
using System;
using System.Collections.Generic;

namespace SkullJocks.BenAdmin.Domain.Entities.Customers
{
    public class CustomerType : AuditEntity
    {
        public Guid CustomerTypeId { get; set; }
        public string CustomerTypeName { get; set; }
    }
}

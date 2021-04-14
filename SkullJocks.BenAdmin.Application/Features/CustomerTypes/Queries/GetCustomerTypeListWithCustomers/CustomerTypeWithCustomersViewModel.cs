using System;
using System.Collections.Generic;
using System.Text;

namespace SkullJocks.BenAdmin.Application.Features.CustomerTypes.Queries.GetCustomerTypeListWithCustomers
{
    public class CustomerTypeWithCustomersViewModel
    {
        public Guid CustomerTypeId { get; set; }
        public string CustomerTypeName { get; set; }
        public ICollection<CustomerTypeWithCustomerDto> Customers { get; set; }

    }
}

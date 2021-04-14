using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkullJocks.BenAdmin.App.ViewModels
{
    public class CustomerTypeIncludingCustomerVm
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public ICollection<CustomerListVm> Customers { get; set; }
    }
}

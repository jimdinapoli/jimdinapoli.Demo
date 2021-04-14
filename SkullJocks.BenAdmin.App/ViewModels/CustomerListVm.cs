using System;

namespace SkullJocks.BenAdmin.App.ViewModels
{
    public class CustomerListVm
    {
        public Guid CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPhone { get; set; }
        public Guid CustomerTypeId { get; set; }
    }
}
using System;

namespace SkullJocks.BenAdmnin.Application.Features.Customers
{
    public class CustomerListModel
    {
        public Guid CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPhone { get; set; }
    }
}

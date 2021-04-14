using System;

namespace SkullJocks.BenAdmin.Application.Features.CustomerTypes.Queries.GetCustomerTypeListWithCustomers
{
    public class CustomerTypeWithCustomerDto
    {
        public Guid CustomerId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public string CompanyEmailAddress { get; set; }
        public string CompanyPhone { get; set; }
        public string CompanyPhoneExtension { get; set; }
        public Guid CustomerTypeId { get; set; }
    }
}

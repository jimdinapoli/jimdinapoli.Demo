using System;

namespace SkullJocks.BenAdmin.Application.Features.CustomerTypes.Commands.CreateCustomerType
{
    public class CreateCustomerTypeDto
    {
        public Guid Id { get; set; }
        public string CustomerTypeName { get; set; }
    }
}

using SkullJocks.BenAdmin.Application.Responses;

namespace SkullJocks.BenAdmin.Application.Features.Customers.Commands.CreateCustomer
{
    public class CreateCustomerCommandResponse : BaseResponse
    {
        public CreateCustomerCommandResponse() : base()
        {
        }

        public CreateCustomerViewModel Customer { get; set; }
    }
}

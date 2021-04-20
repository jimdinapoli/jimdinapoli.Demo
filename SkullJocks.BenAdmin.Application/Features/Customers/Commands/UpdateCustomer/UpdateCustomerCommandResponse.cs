using SkullJocks.BenAdmin.Application.Responses;

namespace SkullJocks.BenAdmin.Application.Features.Customers.Commands.UpdateCustomer
{
    public class UpdateCustomerCommandResponse : BaseResponse
    {
        public UpdateCustomerCommandResponse() : base()
        {
        }

        public UpdateCustomerCommandViewModel Customer { get; set; }
    }
}

using SkullJocks.BenAdmin.Application.Responses;

namespace SkullJocks.BenAdmin.Application.Features.CustomerTypes.Commands.CreateCustomerType
{
    public class CreateCustomerTypeCommandResponse : BaseResponse
    {
        public CreateCustomerTypeCommandResponse() : base()
        {
        }

        public CreateCustomerTypeDto CustomerType { get; set; }
    }
}

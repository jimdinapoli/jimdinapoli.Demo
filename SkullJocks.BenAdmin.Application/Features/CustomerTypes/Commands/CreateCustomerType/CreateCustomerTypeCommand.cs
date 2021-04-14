using MediatR;

namespace SkullJocks.BenAdmin.Application.Features.CustomerTypes.Commands.CreateCustomerType
{
    public class CreateCustomerTypeCommand : IRequest<CreateCustomerTypeCommandResponse>
    {
        public string Name { get; set; }
    }
}

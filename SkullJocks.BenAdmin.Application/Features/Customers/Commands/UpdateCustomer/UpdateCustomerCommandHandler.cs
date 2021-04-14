using AutoMapper;
using MediatR;
using SkullJocks.BenAdmin.Application.Contracts.Persistence;
using SkullJocks.BenAdmin.Domain.Entities.Customers;
using System.Threading;
using System.Threading.Tasks;

namespace SkullJocks.BenAdmin.Application.Features.Customers.Commands.UpdateCustomer
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Customer> _customerRepository;

        public UpdateCustomerCommandHandler(IMapper mapper, IAsyncRepository<Customer> customerRepository)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
        }

        public async Task<Unit> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetByIdAsync(request.CustomerId);
            _mapper.Map(request, customer, typeof(UpdateCustomerCommand), typeof(Customer));
            await _customerRepository.UpdateAsync(customer);
            return Unit.Value;
        }
    }
}

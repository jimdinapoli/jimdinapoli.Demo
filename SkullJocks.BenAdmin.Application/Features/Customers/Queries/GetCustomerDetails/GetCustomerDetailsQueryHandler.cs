using AutoMapper;
using MediatR;
using SkullJocks.BenAdmin.Application.Contracts.Persistence;
using SkullJocks.BenAdmin.Application.Exceptions;
using SkullJocks.BenAdmin.Domain.Entities.Customers;
using System.Threading;
using System.Threading.Tasks;

namespace SkullJocks.BenAdmin.Application.Features.Customers.Queries.GetCustomerDetails
{
    public class GetCustomerDetailsQueryHandler : IRequestHandler<GetCustomerDetailsQuery, CustomerDetailsViewModel>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Customer> _customerRepository;

        public GetCustomerDetailsQueryHandler(IMapper mapper, IAsyncRepository<Customer> customerRepository)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
        }
        public async Task<CustomerDetailsViewModel> Handle(GetCustomerDetailsQuery request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetByIdAsync(request.Id);
            var customerDetailDto = _mapper.Map<CustomerDetailsViewModel>(customer);

            var customerType = await _customerRepository.GetByIdAsync(customer.CustomerId);

            if (customerType == null)
            {
                throw new NotFoundException(nameof(Customer), request.Id);
            }
            customerDetailDto.CustomerType = _mapper.Map<CustomerTypeDto>(customerType);

            return customerDetailDto;
        }
    }
}

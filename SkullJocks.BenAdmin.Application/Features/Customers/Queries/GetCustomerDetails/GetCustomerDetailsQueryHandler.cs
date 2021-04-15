using AutoMapper;
using MediatR;
using SkullJocks.BenAdmin.Application.Contracts.Persistence;
using SkullJocks.BenAdmin.Application.Exceptions;
using SkullJocks.BenAdmin.Domain.Entities.Customers;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SkullJocks.BenAdmin.Application.Features.Customers.Queries.GetCustomerDetails
{
    public class GetCustomerDetailsQueryHandler : IRequestHandler<GetCustomerDetailsQuery, CustomerDetailsViewModel>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Customer> _customerRepository;
        private readonly IAsyncRepository<CustomerType> _customerTypeRepository;

        public GetCustomerDetailsQueryHandler(IMapper mapper, IAsyncRepository<Customer> customerRepository, IAsyncRepository<CustomerType> customerTypeRepository)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
            _customerTypeRepository = customerTypeRepository;
        }
        public async Task<CustomerDetailsViewModel> Handle(GetCustomerDetailsQuery request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetByIdAsync(request.Id);
            var customerDetailDto = _mapper.Map<CustomerDetailsViewModel>(customer);

            var customerType = await _customerTypeRepository.GetByIdAsync(customer.CustomerTypeId);
            if (customerType == null)
            {
                throw new NotFoundException(nameof(Customer), request.Id);
            }

            customerDetailDto.CustomerTypeDto = new CustomerTypeDto() { CustomerTypeId = customerType.CustomerTypeId, CustomerTypeName = customerType.CustomerTypeName };
            customerDetailDto.CustomerTypeDto.CustomerTypeId = customerType.CustomerTypeId;
            customerDetailDto.CustomerTypeDto.CustomerTypeName = customerType.CustomerTypeName;

            return customerDetailDto;
        }
    }
}

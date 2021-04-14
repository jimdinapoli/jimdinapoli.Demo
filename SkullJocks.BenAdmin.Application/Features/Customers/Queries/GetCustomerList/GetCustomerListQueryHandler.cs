using AutoMapper;
using MediatR;
using SkullJocks.BenAdmin.Application.Contracts.Persistence;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using SkullJocks.BenAdmin.Domain.Entities.Customers;

namespace SkullJocks.BenAdmnin.Application.Features.Customers
{
    public class GetCustomerListQueryHandler : IRequestHandler<GetCustomerListQuery, List<CustomerListModel>>
    {
        private readonly IAsyncRepository<Customer> _customerRepository;
        private readonly IMapper _mapper;

        public GetCustomerListQueryHandler(IMapper mapper, IAsyncRepository<Customer> customerRepository)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<List<CustomerListModel>> Handle(GetCustomerListQuery request, CancellationToken cancellationToken)
        {
            var allCusotmers = (await _customerRepository.ListAllAsync()).OrderBy(x => x.CustomerName);
            return _mapper.Map<List<CustomerListModel>>(allCusotmers);
        }
    }
}

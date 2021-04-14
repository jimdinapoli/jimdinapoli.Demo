using AutoMapper;
using MediatR;
using SkullJocks.BenAdmin.Application.Contracts.Persistence;
using SkullJocks.BenAdmin.Domain.Entities.Customers;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace SkullJocks.BenAdmin.Application.Features.CustomerTypes.Queries.GetCustomerTypeList
{
    public class GetCustomerTypeListQueryHandler : IRequestHandler<GetCustomerTypeListQuery, List<CustomerTypeListViewModel>>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<CustomerType> _customerTypeRepository;

        public GetCustomerTypeListQueryHandler(IMapper mapper, IAsyncRepository<CustomerType> customerTypeRepository)
        {
            _mapper = mapper;
            _customerTypeRepository = customerTypeRepository;
        }
        public async Task<List<CustomerTypeListViewModel>> Handle(GetCustomerTypeListQuery request, CancellationToken cancellationToken)
        {
            var customerTypes = (await _customerTypeRepository.ListAllAsync()).OrderBy(x => x.CustomerTypeName);
            return _mapper.Map<List<CustomerTypeListViewModel>>(customerTypes);
        }
    }
}

using AutoMapper;
using MediatR;
using SkullJocks.BenAdmin.Application.Contracts.Persistence;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SkullJocks.BenAdmin.Application.Features.CustomerTypes.Queries.GetCustomerTypeListWithCustomers
{
    public class GetCustomerTypesIncludingCustomersQueryHandler : IRequest<List<CustomerTypeWithCustomersViewModel>>
    {
        private readonly IMapper _mapper;
        private readonly ICustomerTypeRepository _customerTypeRepository;

        public GetCustomerTypesIncludingCustomersQueryHandler(IMapper mapper, ICustomerTypeRepository customerTypeRepository)
        {
            _mapper = mapper;
            _customerTypeRepository = customerTypeRepository;
        }

        //public async Task<List<CustomerTypeWithCustomersViewModel>> Handle(GetCustomerTypesIncludingCustomersQuery request, CancellationToken cancellation)
        //{
        //    var list = await _customerTypeRepository.GetCustomerTypesIncludingCustomers();
        //    return _mapper.Map<List<CustomerTypeWithCustomersViewModel>>(list);
        //}
    }
}

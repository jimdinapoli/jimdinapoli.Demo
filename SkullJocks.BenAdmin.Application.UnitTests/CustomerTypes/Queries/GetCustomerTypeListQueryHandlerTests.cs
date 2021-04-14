using AutoMapper;
using Moq;
using SkullJocks.BenAdmin.Application.Contracts.Persistence;
using SkullJocks.BenAdmin.Domain.Entities.Customers;

namespace SkullJocks.BenAdmin.Application.UnitTests.CustomerTypes.Queries
{
    public class GetCustomerTypeListQueryHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IAsyncRepository<CustomerType>> _mockCustomerTypeRespoitory;

        public GetCustomerTypeListQueryHandlerTests()
        {
        }
    }
}

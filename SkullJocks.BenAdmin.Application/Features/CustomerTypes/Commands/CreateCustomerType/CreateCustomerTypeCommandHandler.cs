using AutoMapper;
using MediatR;
using SkullJocks.BenAdmin.Application.Contracts.Persistence;
using SkullJocks.BenAdmin.Domain.Entities.Customers;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SkullJocks.BenAdmin.Application.Features.CustomerTypes.Commands.CreateCustomerType
{
    public class CreateCustomerTypeCommandHandler : IRequestHandler<CreateCustomerTypeCommand, CreateCustomerTypeCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<CustomerType> _customerTypeRepository;

        public CreateCustomerTypeCommandHandler(IMapper mapper, IAsyncRepository<CustomerType> customerTypeRepository)
        {
            _mapper = mapper;
            _customerTypeRepository = customerTypeRepository;
        }
        public async Task<CreateCustomerTypeCommandResponse> Handle(CreateCustomerTypeCommand request, CancellationToken cancellationToken)
        {
            var createCustomerTypeCommandResponse = new CreateCustomerTypeCommandResponse();

            var validator = new CreateCustomerTypeCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                createCustomerTypeCommandResponse.Success = false;
                createCustomerTypeCommandResponse.ValidationErrors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    createCustomerTypeCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }

            if (createCustomerTypeCommandResponse.Success)
            {
                var customerType = new CustomerType { CustomerTypeName = request.Name };
                customerType = await _customerTypeRepository.AddAsync(customerType);
                createCustomerTypeCommandResponse.CustomerType = _mapper.Map<CreateCustomerTypeDto>(customerType);
            }
            return createCustomerTypeCommandResponse;
        }
    }
}

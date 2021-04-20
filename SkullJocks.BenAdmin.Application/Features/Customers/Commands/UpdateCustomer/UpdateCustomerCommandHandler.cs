using AutoMapper;
using MediatR;
using SkullJocks.BenAdmin.Application.Contracts.Persistence;
using SkullJocks.BenAdmin.Application.Exceptions;
using SkullJocks.BenAdmin.Application.Validators;
using SkullJocks.BenAdmin.Domain.Entities.Customers;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SkullJocks.BenAdmin.Application.Features.Customers.Commands.UpdateCustomer
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, UpdateCustomerCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Customer> _customerRepository;

        public UpdateCustomerCommandHandler(IMapper mapper, IAsyncRepository<Customer> customerRepository)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
        }

        public async Task<UpdateCustomerCommandResponse> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var response = new UpdateCustomerCommandResponse();

            var validator = new UpdateCustomerCommandValidator();
            var result = await validator.ValidateAsync(request);

            if (result.Errors.Count > 0)
            {
                response.Success = false;
                response.ValidationErrors = new List<string>();
                foreach (var error in result.Errors)
                    response.ValidationErrors.Add(error.ErrorMessage);
            }

            if (result.Errors.Count > 0)
            {
                throw new ValidationException(result);
            }

            if (response.Success)
            {
                var customer = _mapper.Map<Customer>(request);
                await _customerRepository.UpdateAsync(customer);
                response.Customer = _mapper.Map<UpdateCustomerCommandViewModel>(customer);
            }
            return response;
        }
    }
}

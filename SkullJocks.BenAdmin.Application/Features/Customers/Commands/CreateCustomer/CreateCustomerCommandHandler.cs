using AutoMapper;
using MediatR;
using SkullJocks.BenAdmin.Application.Contracts.Persistence;
using SkullJocks.BenAdmin.Application.Exceptions;
using SkullJocks.BenAdmin.Application.Responses;
using SkullJocks.BenAdmin.Application.Validators;
using SkullJocks.BenAdmin.Domain.Entities.Customers;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SkullJocks.BenAdmin.Application.Features.Customers.Commands.CreateCustomer
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, CreateCustomerCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Customer> _customerRepository;

        public CreateCustomerCommandHandler(IMapper mapper, IAsyncRepository<Customer> customerRepository)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
        }
        public async Task<CreateCustomerCommandResponse> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var response = new CreateCustomerCommandResponse();

            var validator = new CreateCustomerCommandValidator();
            var result = await validator.ValidateAsync(request);

            if (result.Errors.Count > 0)
            {
                response.Success = false;
                response.ValidationErrors = new List<string>();
                foreach (var error in result.Errors)
                    response.ValidationErrors.Add(error.ErrorMessage);
            }

            if(result.Errors.Count > 0)
            {
                throw new ValidationException(result);
            }

            if (response.Success)
            {
                var customer = _mapper.Map<Customer>(request);
                customer = await _customerRepository.AddAsync(customer);
                response.Customer = _mapper.Map<CreateCustomerViewModel>(customer);
            }
            return response;
        }
    }
}

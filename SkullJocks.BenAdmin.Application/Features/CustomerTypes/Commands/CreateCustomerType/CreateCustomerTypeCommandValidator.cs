using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkullJocks.BenAdmin.Application.Features.CustomerTypes.Commands.CreateCustomerType
{
    public class CreateCustomerTypeCommandValidator : AbstractValidator<CreateCustomerTypeCommand>
    {
        public CreateCustomerTypeCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");
        }
    }
}

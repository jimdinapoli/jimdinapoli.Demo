using FluentValidation;
using FluentValidation.Validators;
using SkullJocks.BenAdmin.Application.Features.Customers.Commands.CreateCustomer;

namespace SkullJocks.BenAdmin.Application.Validators
{
    public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerCommandValidator()
        {
            RuleFor(x => x.CustomerName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(25).WithMessage("{PropertyName} connot be more than 25 characters.");

            RuleFor(x => x.CustomerPhone)
                .NotNull()
                .SetValidator(new RegularExpressionValidator(@"((?:[0-9]\-?){6,14}[0-9]$)|((?:[0-9]\x20?){6,14}[0-9]$)"));
        }
    }
}

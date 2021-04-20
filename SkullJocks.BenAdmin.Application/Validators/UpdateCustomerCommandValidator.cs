using FluentValidation;
using FluentValidation.Validators;
using SkullJocks.BenAdmin.Application.Features.Customers.Commands.UpdateCustomer;

namespace SkullJocks.BenAdmin.Application.Validators
{
    public class UpdateCustomerCommandValidator : AbstractValidator<UpdateCustomerCommand>
    {
        public UpdateCustomerCommandValidator()
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

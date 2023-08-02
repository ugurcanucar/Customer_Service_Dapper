using Customer_Service.Application.Mediatr.Commands.Customer;
using FluentValidation;

namespace Customer_Service.Application.Validators.Customer;

public class RegisterValidation : AbstractValidator<RegisterCustomerCommand>
{
    public RegisterValidation()
    {
        RuleFor(c => c.Password).MinimumLength(6).WithMessage("Minimum length must be 6 for Password");
        RuleFor(c => c.Name).MinimumLength(6).WithMessage("Minimum length must be 6 for Name");
        RuleFor(c => c.Surname).MinimumLength(6).WithMessage("Minimum length must be 6 for Surname");
        RuleFor(c => c.Email).EmailAddress().WithMessage("Enter valid email address");
    }
}
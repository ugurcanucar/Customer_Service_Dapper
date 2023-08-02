using Customer_Service.Application.Mediatr.Commands.Customer;
using FluentValidation;

namespace Customer_Service.Application.Validators.Customer;

public class LoginValidation : AbstractValidator<LoginCommand>
{
    public LoginValidation()
    {
        RuleFor(c => c.Password).MinimumLength(6).WithMessage("Minimum length must be 6 for Password"); 
        RuleFor(c => c.Email).EmailAddress().WithMessage("Enter valid email address");
    }
}
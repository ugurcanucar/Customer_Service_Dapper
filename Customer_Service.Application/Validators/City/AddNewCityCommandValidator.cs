using Customer_Service.Application.Mediatr.Commands.City;
using Customer_Service.DTO.City;
using FluentValidation;

namespace Customer_Service.Application.Validators.City;

public class AddNewCityCommandValidator:AbstractValidator<AddNewCityCommand>
{
    public AddNewCityCommandValidator()
    {
        RuleFor(c => c.Name).MinimumLength(6).WithMessage("Minimum 6 harfli bir şehir girmelisiniz.");
    }
}
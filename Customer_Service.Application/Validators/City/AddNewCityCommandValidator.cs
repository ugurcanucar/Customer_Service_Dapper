using Customer_Service.Application.Mediatr.Commands.City;
using Customer_Service.DTO.City;
using FluentValidation;

namespace Customer_Service.Application.Validators.City;

public class AddNewCityCommandValidator:AbstractValidator<AddNewCityCommand>
{
    public AddNewCityCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty().WithMessage("City Name Can't Be Empty"); 
        RuleFor(c => c.Name).MinimumLength(3).WithMessage("You must enter atleast 3 letter for city.");
    }
}
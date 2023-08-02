using Customer_Service.Application.Helpers.ValidationHelper;
using Customer_Service.Application.Interfaces;
using Customer_Service.Application.Validators.City;
using Customer_Service.DTO.City;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Customer_Service.Application.Mediatr.Commands.City.Handlers;

public class AddNewCityHandler : IRequestHandler<AddNewCityCommand, AddedCityDto?>
{
    private readonly IUnitOfWork _unitOfWork; 
    private readonly IValidator<AddNewCityCommand> _validator;

    public AddNewCityHandler(IUnitOfWork unitOfWork, IValidator<AddNewCityCommand> validator)
    {
        _unitOfWork = unitOfWork;
        _validator = validator;
    }

    public async Task<AddedCityDto?> Handle(AddNewCityCommand request, CancellationToken cancellationToken)
    {
        bool isValid = await CheckValidate<AddNewCityCommand>.CheckIsValid(request, _validator);
        if (isValid)
        {
            Entities.City newCity = new Entities.City() { Name = request.Name }; 
            Entities.City? addedCity = await _unitOfWork.Cities.AddAsync(newCity);
            return AddedCityDto.ToAddedCityDto(addedCity); 
        }

        return null;
    }
}
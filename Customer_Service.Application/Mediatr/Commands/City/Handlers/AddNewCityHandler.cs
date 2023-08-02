using Customer_Service.Application.Interfaces;
using Customer_Service.DTO.City;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Customer_Service.Application.Mediatr.Commands.City.Handlers;

public class AddNewCityHandler : IRequestHandler<AddNewCityCommand, AddedCityDto>
{
    private readonly IUnitOfWork _unitOfWork; 

    public AddNewCityHandler(IUnitOfWork unitOfWork )
    {
        _unitOfWork = unitOfWork; 
    }

    public async Task<AddedCityDto> Handle(AddNewCityCommand request, CancellationToken cancellationToken)
    {
        Entities.City newCity = new Entities.City() { Name = request.Name }; 
        Entities.City? addedCity = await _unitOfWork.Cities.AddAsync(newCity);
        return AddedCityDto.ToAddedCityDto(addedCity); 
    }
}
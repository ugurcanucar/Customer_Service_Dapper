using Customer_Service.Application.Helpers.ValidationHelper;
using Customer_Service.Application.Interfaces;
using Customer_Service.DTO.City;
using FluentValidation;
using MediatR;

namespace Customer_Service.Application.Mediatr.Commands.City.Handlers;

public class UpdateCityHandler : IRequestHandler<UpdateCityCommand, UpdateCityDto?>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IValidator<UpdateCityCommand> _validator;

    public UpdateCityHandler(IUnitOfWork unitOfWork, IValidator<UpdateCityCommand> validator)
    {
        _unitOfWork = unitOfWork;
        _validator = validator;
    }

    public async Task<UpdateCityDto?> Handle(UpdateCityCommand request, CancellationToken cancellationToken)
    {
        bool isValid = await CheckValidate<UpdateCityCommand>.CheckIsValid(request, _validator);
        if (isValid)
        {
            Entities.City entityCity = UpdateCityCommand.ToEntity(request);
            Entities.City? updatedCity = await _unitOfWork.Cities.UpdateAsync(entityCity);
            return UpdateCityDto.ToUpdateCityDto(updatedCity);
        }
        return null;
    }
}
using Customer_Service.Application.Interfaces;
using Customer_Service.DTO.City;
using MediatR;

namespace Customer_Service.Application.Mediatr.Commands.City.Handlers;

public class UpdateCityHandler : IRequestHandler<UpdateCityCommand, UpdateCityDto>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateCityHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<UpdateCityDto> Handle(UpdateCityCommand request, CancellationToken cancellationToken)
    {
        Entities.City model = new Entities.City()
        {
            Id = request.Id, Name = request.Name
        };
        Entities.City updatedCity = await _unitOfWork.Cities.UpdateAsync(model);
        return UpdateCityDto.ToUpdateCityDto(updatedCity);
    }
}
using Customer_Service.Application.Interfaces;
using Customer_Service.DTO.City;
using MediatR;

namespace Customer_Service.Application.Mediatr.Queries.City.Handlers;

public class GetCityByIdHandler:IRequestHandler<GetCityByIdQuery,CityListDto?>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetCityByIdHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<CityListDto?> Handle(GetCityByIdQuery request, CancellationToken cancellationToken)
    {
        Entities.City city = await _unitOfWork.Cities.GetByIdAsync(request.Id);
        
        return CityListDto.ToCityListDto(city);
    }
}
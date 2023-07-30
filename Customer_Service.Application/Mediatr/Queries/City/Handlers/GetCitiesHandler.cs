using Customer_Service.Application.Interfaces;
using Customer_Service.DTO.City;
using MediatR;

namespace Customer_Service.Application.Mediatr.Queries.City.Handlers;

public class GetCitiesHandler : IRequestHandler<GetCitiesQuery, IEnumerable<CityListDto>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetCitiesHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<CityListDto>> Handle(GetCitiesQuery request, CancellationToken cancellationToken)
    {
        IEnumerable<Entities.City> city = await _unitOfWork.Cities.GetAllAsync();
        return city.Select(CityListDto.ToCityListDto);
    }
}
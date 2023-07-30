using Customer_Service.DTO;
using Customer_Service.DTO.City;
using MediatR;

namespace Customer_Service.Application.Mediatr.Queries.City;

public class GetCityByIdQuery:IRequest<CityListDto?>
{
    public int Id { get; set; }
}
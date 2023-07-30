using Customer_Service.DTO;
using Customer_Service.DTO.City;
using MediatR;

namespace Customer_Service.Application.Mediatr.Queries.City;

public class GetCitiesQuery:IRequest<IEnumerable<CityListDto>>
{
    
}
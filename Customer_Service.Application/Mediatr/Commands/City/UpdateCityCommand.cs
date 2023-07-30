using Customer_Service.DTO.City;
using MediatR;

namespace Customer_Service.Application.Mediatr.Commands.City;

public class UpdateCityCommand:IRequest<UpdateCityDto>
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}
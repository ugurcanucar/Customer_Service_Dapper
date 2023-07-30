using Customer_Service.DTO.City;
using MediatR;
namespace Customer_Service.Application.Mediatr.Commands.City;


public class AddNewCityCommand:IRequest<AddedCityDto>
{
    public string Name { get; set; } = string.Empty;
}
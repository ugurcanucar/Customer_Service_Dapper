using MediatR;

namespace Customer_Service.Application.Mediatr.Commands.City;

public class DeleteCityCommand:IRequest<bool>
{
    public int Id { get; set; }
}
using Customer_Service.DTO;
using Customer_Service.DTO.Customer;
using MediatR;

namespace Customer_Service.Application.Mediatr.Commands.Customer;

public class UpdateCustomerCommand:IRequest<CustomerDto?>
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
    public int CityId { get; set; }

    public static Entities.Customer ToEntity(UpdateCustomerCommand command)
    {
        return new Entities.Customer()
        {
            Id = command.Id,
            Email = command.Email,
            Name = command.Name,
            CityId = command.CityId,
            Surname = command.Surname,
        };
    }
}
using Customer_Service.DTO;
using Customer_Service.DTO.Customer;
using MediatR;

namespace Customer_Service.Application.Mediatr.Commands.Customer;

public class AddNewCustomerCommand:IRequest<CustomerDto>
{
    public string Name { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public int CityId { get; set; }

    public static Entities.Customer ToEntity(AddNewCustomerCommand customer)
    {
        return new Entities.Customer()
        {
            
            Name = customer.Name,
            CityId = customer.CityId,
            Surname = customer.Surname,
            PhoneNumber = customer.PhoneNumber,
            Email = customer.Email,
            
        };
    }
}
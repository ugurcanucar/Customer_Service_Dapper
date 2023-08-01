using Customer_Service.DTO;
using Customer_Service.DTO.Customer;
using MediatR;

namespace Customer_Service.Application.Mediatr.Commands.Customer;

public class RegisterCustomerCommand:IRequest<RegisterCustomerResponseDto>
{
    public string Name { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public int CityId { get; set; }
    public string Email { get; set; } = string.Empty;
    
    public string Password { get; set; } = string.Empty;

    public static RegisterCustomerRequestDto ToRegisterCustomerRequestDto(RegisterCustomerCommand customer)
    {
        return new RegisterCustomerRequestDto()
        {
            Name = customer.Name,
            CityId = customer.CityId,
            Surname = customer.Surname,
            PhoneNumber = customer.PhoneNumber,
            Email = customer.Email,
            Password = customer.Password,
            
        };
    }
}
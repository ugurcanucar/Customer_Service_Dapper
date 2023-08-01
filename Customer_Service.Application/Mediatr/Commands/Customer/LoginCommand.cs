using Customer_Service.DTO.Customer;
using MediatR;

namespace Customer_Service.Application.Mediatr.Commands.Customer;

public class LoginCommand:IRequest<LoginResponseDto?>
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;


    public static LoginRequestDto ToLoginRequestDto(LoginCommand loginCommand)
    {
        return new LoginRequestDto()
        {
            Email = loginCommand.Email,
            Password = loginCommand.Password,
        };
    }
}
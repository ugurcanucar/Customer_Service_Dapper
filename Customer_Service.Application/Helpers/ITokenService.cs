using Customer_Service.DTO.Customer; 

namespace Customer_Service.Application.Helpers;

public interface ITokenService
{
    string CreateToken(LoginResponseDto customer);
}
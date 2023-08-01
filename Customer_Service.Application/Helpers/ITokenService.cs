using Customer_Service.DTO.Customer;
using Customer_Service.Entities;

namespace Customer_Service.Application.Helpers;

public interface ITokenService
{
    string CreateToken(LoginResponseDto customer);
}
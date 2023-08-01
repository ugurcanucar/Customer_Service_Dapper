using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Customer_Service.DTO.Customer;
using Customer_Service.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Customer_Service.Application.Helpers;

public class TokenService:ITokenService
{
    private readonly IConfiguration _configuration;
    
    public TokenService(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    public string CreateToken(LoginResponseDto customer)
    {
        List<Claim> claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name,customer.Name),
            new Claim(ClaimTypes.Surname,customer.Surname),
            new Claim(ClaimTypes.Email,customer.Email),
            new Claim(ClaimTypes.MobilePhone,customer.PhoneNumber),
            new Claim(ClaimTypes.Sid,customer.Id.ToString()),
        };
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
            _configuration.GetSection("JwtSettings:Key").Value!
            ));
        var creds = new SigningCredentials(key,SecurityAlgorithms.HmacSha512Signature);

        var token =new JwtSecurityToken(
            claims:claims,
            expires:DateTime.Now.AddDays(1),
            audience:_configuration.GetSection("JwtSettings:Audience").Value,
            issuer:_configuration.GetSection("JwtSettings:Issuer").Value,
            signingCredentials:creds
        );
        var jwt = new JwtSecurityTokenHandler().WriteToken(token);
        return jwt;
    }
}
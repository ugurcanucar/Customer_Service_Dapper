using Customer_Service.Application.Helpers;
using Customer_Service.Application.Interfaces;
using Customer_Service.DTO.Customer;
using MediatR;

namespace Customer_Service.Application.Mediatr.Commands.Customer.Handlers;

public class LoginHandler : IRequestHandler<LoginCommand, LoginResponseDto?>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ITokenService _tokenService;

    public LoginHandler(IUnitOfWork unitOfWork, ITokenService tokenService)
    {
        _unitOfWork = unitOfWork;
        _tokenService = tokenService;
    }

    public async Task<LoginResponseDto?> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var login = LoginCommand.ToLoginRequestDto(request);
        var customerByEmail = await _unitOfWork.Customers.GetCustomerByEmailAsync(request.Email);
        bool isMatch = BCrypt.Net.BCrypt.Verify(request.Password, customerByEmail.PasswordHash);
        if (isMatch)
        {
            LoginResponseDto loginResponseDto = LoginResponseDto.fromEntity(customerByEmail);
            loginResponseDto.Token = _tokenService.CreateToken(loginResponseDto);
            return loginResponseDto;
        }

        return null;
    }
}
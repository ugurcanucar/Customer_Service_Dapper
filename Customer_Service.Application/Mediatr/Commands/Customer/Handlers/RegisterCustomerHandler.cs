using Customer_Service.Application.Interfaces;
using Customer_Service.DTO;
using Customer_Service.DTO.Customer;
using MediatR;

namespace Customer_Service.Application.Mediatr.Commands.Customer.Handlers;

public class RegisterCustomerHandler:IRequestHandler<RegisterCustomerCommand,RegisterCustomerResponseDto>
{
    private readonly IUnitOfWork _unitOfWork;

    public RegisterCustomerHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<RegisterCustomerResponseDto> Handle(RegisterCustomerCommand request, CancellationToken cancellationToken)
    {
        int salt = 12;
        request.Password = BCrypt.Net.BCrypt.HashPassword(request.Password,salt);
        RegisterCustomerRequestDto customer = RegisterCustomerCommand.ToRegisterCustomerRequestDto(request);
        Entities.Customer addedCustomer=await _unitOfWork.Customers.RegisterAsync(customer);
        return RegisterCustomerResponseDto.fromEntity(addedCustomer);

    }
}
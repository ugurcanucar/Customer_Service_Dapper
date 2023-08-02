using Customer_Service.Application.Helpers.ValidationHelper;
using Customer_Service.Application.Interfaces;
using Customer_Service.DTO;
using Customer_Service.DTO.Customer;
using FluentValidation;
using MediatR;

namespace Customer_Service.Application.Mediatr.Commands.Customer.Handlers;

public class RegisterCustomerHandler:IRequestHandler<RegisterCustomerCommand,RegisterCustomerResponseDto?>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IValidator<RegisterCustomerCommand> _validator;

    public RegisterCustomerHandler(IUnitOfWork unitOfWork, IValidator<RegisterCustomerCommand> validator)
    {
        _unitOfWork = unitOfWork;
        _validator = validator;
    }

    public async Task<RegisterCustomerResponseDto?> Handle(RegisterCustomerCommand request, CancellationToken cancellationToken)
    {
        bool isValid = await CheckValidate<RegisterCustomerCommand>.CheckIsValid(request, _validator);
        if (isValid)
        {
            int salt = 12;
            request.Password = BCrypt.Net.BCrypt.HashPassword(request.Password,salt);
            RegisterCustomerRequestDto customer = RegisterCustomerCommand.ToRegisterCustomerRequestDto(request);
            Entities.Customer addedCustomer=await _unitOfWork.Customers.RegisterAsync(customer);
            return RegisterCustomerResponseDto.fromEntity(addedCustomer);
        }

        return null;


    }
}
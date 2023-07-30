using Customer_Service.Application.Interfaces;
using Customer_Service.DTO;
using Customer_Service.DTO.Customer;
using MediatR;

namespace Customer_Service.Application.Mediatr.Commands.Customer.Handlers;

public class AddNewCustomerHandler:IRequestHandler<AddNewCustomerCommand,CustomerDto>
{
    private readonly IUnitOfWork _unitOfWork;

    public AddNewCustomerHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<CustomerDto> Handle(AddNewCustomerCommand request, CancellationToken cancellationToken)
    {
        Entities.Customer customer = AddNewCustomerCommand.ToEntity(request);
        Entities.Customer addedCustomer=await _unitOfWork.Customers.AddAsync(customer);
        return CustomerDto.ToCustomerDto(addedCustomer);
    }
}
using Customer_Service.Application.Interfaces;
using Customer_Service.DTO;
using Customer_Service.DTO.Customer;
using MediatR;

namespace Customer_Service.Application.Mediatr.Commands.Customer.Handlers;

public class UpdateCustomerHandler : IRequestHandler<UpdateCustomerCommand, CustomerDto?>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateCustomerHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<CustomerDto?> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        Entities.Customer customerModel = UpdateCustomerCommand.ToEntity(request);
        Entities.Customer? customerEntity = await _unitOfWork.Customers.UpdateAsync(customerModel); 
        return CustomerDto.ToCustomerDto(customerEntity);
    }
}
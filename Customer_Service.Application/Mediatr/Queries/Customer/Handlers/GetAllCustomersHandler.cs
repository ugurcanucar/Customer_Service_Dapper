using Customer_Service.Application.Interfaces;
using Customer_Service.Application.Mediatr.Queries.Customer.Sqls;
using Customer_Service.DTO;
using Customer_Service.DTO.Customer;
using MediatR;

namespace Customer_Service.Application.Mediatr.Queries.Customer.Handlers;

public class GetAllCustomersHandler : IRequestHandler<GetAllCustomerQuery, IEnumerable<CustomerDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    
    public GetAllCustomersHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<CustomerDto>> Handle(GetAllCustomerQuery request, CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.Customers.GetAllAsync();
        return result.Select(CustomerDto.ToCustomerDto);

    }
}
using Customer_Service.DTO;
using Customer_Service.DTO.Customer;
using MediatR;

namespace Customer_Service.Application.Mediatr.Queries.Customer;

public class GetCustomerByIdQuery : IRequest<CustomerDto?>
{
    public int Id { get; set; }
}
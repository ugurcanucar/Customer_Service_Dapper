using Customer_Service.DTO;
using Customer_Service.DTO.Customer;
using MediatR;

namespace Customer_Service.Application.Mediatr.Queries.Customer;

public class GetAllCustomerQuery: IRequest<IEnumerable<CustomerDto>>
{ 
}
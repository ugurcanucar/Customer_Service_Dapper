using Customer_Service.Application.Mediatr.Commands.Customer;
using Customer_Service.DTO;
using Customer_Service.DTO.Customer;
using Customer_Service.Entities;

namespace Customer_Service.Application.Interfaces;

public interface ICustomerRepository:IGenericRepository<Customer>
{
    
}
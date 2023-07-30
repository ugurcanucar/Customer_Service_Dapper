namespace Customer_Service.Application.Interfaces;

public interface IUnitOfWork
{
    ICustomerRepository Customers { get; }
    ICityRepository Cities { get; }
}
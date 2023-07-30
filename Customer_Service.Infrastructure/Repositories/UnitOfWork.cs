using Customer_Service.Application.Interfaces;

namespace Customer_Service.Infrastructure.Repositories;

public class UnitOfWork:IUnitOfWork
{
    public UnitOfWork(ICustomerRepository customerRepository,ICityRepository cityRepository)
    {
        Customers = customerRepository;
        Cities = cityRepository;
    }
    public ICustomerRepository Customers { get; }
    public ICityRepository Cities { get; }
}
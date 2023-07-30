using System.Reflection;
using Customer_Service.Application.Interfaces;
using Customer_Service.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Customer_Service.Infrastructure;

public static class ServiceRegistration
{
    public static void AddInfrastructure(this IServiceCollection services)
    {
        services.AddTransient<ICustomerRepository, CustomerRepository>();
        services.AddTransient<ICityRepository, CityRepository>();
        services.AddTransient<IUnitOfWork, UnitOfWork>();
 
    }
}
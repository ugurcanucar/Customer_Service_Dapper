using System.Reflection;
using Customer_Service.Application.Interfaces;
using Customer_Service.Infrastructure.Helpers;
using Customer_Service.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using DbConnection = System.Data.Common.DbConnection;

namespace Customer_Service.Infrastructure;

public static class ServiceRegistration
{
    public static void AddInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<IDbConnectFactory, DbConnectFactory>();
        services.AddTransient<ICustomerRepository, CustomerRepository>();
        services.AddTransient<ICityRepository, CityRepository>();
        services.AddTransient<IUnitOfWork, UnitOfWork>();
 
    }
}
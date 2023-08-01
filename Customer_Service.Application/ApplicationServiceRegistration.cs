using System.Reflection;
using Customer_Service.Application.Helpers;
using Customer_Service.Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Customer_Service.Application;

public static class ApplicationServiceRegistration
{
    public static void InjectMediatR(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddSingleton<ITokenService, TokenService>();

    }
}
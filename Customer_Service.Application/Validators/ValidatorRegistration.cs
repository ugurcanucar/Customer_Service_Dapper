using System.Reflection;
using Customer_Service.Application.Mediatr.Pipelines;
using Customer_Service.Application.Validators.City;
using Customer_Service.DTO.City;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Customer_Service.Application.Validators;

public static class ValidatorRegistration
{
    public static void InjectValidator(this IServiceCollection service)
    {
        service.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        service.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehavior<,>));
        // service.AddScoped<IValidator<AddedCityDto>, AddCityValidator>();
    }
}
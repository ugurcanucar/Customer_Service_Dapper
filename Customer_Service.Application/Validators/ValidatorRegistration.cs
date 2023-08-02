using System.Reflection;
using Customer_Service.Application.Mediatr.Commands.City;
using Customer_Service.Application.Mediatr.Commands.Customer;
using Customer_Service.Application.Validators.City;
using Customer_Service.Application.Validators.Customer;
using Customer_Service.DTO.City;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Customer_Service.Application.Validators;

public static class ValidatorRegistration
{
    public static void InjectValidator(this IServiceCollection service)
    {
        service.AddScoped<IValidator<AddNewCityCommand>, AddNewCityCommandValidator>(); 
        service.AddScoped<IValidator<UpdateCityCommand>,UpdateCityValidator>(); 
        service.AddScoped<IValidator<RegisterCustomerCommand>, RegisterValidation>(); 
        service.AddScoped<IValidator<LoginCommand>, LoginValidation>(); 
    }
}
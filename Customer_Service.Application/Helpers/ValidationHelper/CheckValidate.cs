using System.Text.Json;
using Customer_Service.DTO.Base;
using FluentValidation;
using MediatR;

namespace Customer_Service.Application.Helpers.ValidationHelper;

public static class CheckValidate<T>
{
    public static async Task<bool> CheckIsValid(T request, IValidator<T> validator)
    {
        var validationResult = await validator.ValidateAsync(request);
        if (!validationResult.IsValid)
        {
            var failures = validationResult.Errors.Select(x => x.ErrorMessage);
            ErrorModel model = new ErrorModel()
            {
                Message = "Validation Error",
                Errors = failures
            };
            var jsonModel = JsonSerializer.Serialize(model);
            throw new Exception(jsonModel);
        }
        return true;
    }
}
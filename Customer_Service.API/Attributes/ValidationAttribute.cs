using Customer_Service.DTO.Base;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Customer_Service_API.Attributes;

public class ValidationAttribute : ExceptionFilterAttribute
{
    public override void OnException(ExceptionContext context)
    {
        if (context.ExceptionHandled) return;
        ErrorModel model = new ErrorModel()
        {
            Message = context.Exception.Message
        }; 
        context.Result = new BadRequestObjectResult(model);
    }
}
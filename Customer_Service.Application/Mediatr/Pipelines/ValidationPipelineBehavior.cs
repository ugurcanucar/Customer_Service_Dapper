using FluentValidation;
using MediatR;

namespace Customer_Service.Application.Mediatr.Pipelines;

public class ValidationPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly IValidator<TRequest> _validator;

    public ValidationPipelineBehavior(IValidator<TRequest> validator)
    {
        _validator = validator;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request);
        if (!validationResult.IsValid)
        {
            var failures = validationResult.Errors.Select(x => x.ErrorMessage);
            string message = "Hata Mevcut => "+string.Join("-",failures);
            throw new Exception(message);
        }

        return await next();
    }
}

 
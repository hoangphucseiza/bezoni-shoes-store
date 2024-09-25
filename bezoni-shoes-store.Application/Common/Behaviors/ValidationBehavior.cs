using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bezoni_shoes_store.Application.Common.Behaviors
{
    //public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    //{
    //    private readonly IValidator<TRequest> _validator;

    //    public ValidationBehavior(IValidator<TRequest> validator)
    //    {
    //        _validator = validator;
    //    }

    //    public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    //    {
    //        var validationResult = await _validator.ValidateAsync(request, cancellationToken);

    //        if (!validationResult.IsValid)
    //        {
    //            throw new ValidationException(validationResult.Errors);
    //        }

    //        return await next();
    //    }
    //}
}

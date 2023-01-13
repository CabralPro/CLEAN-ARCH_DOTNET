using CleanArch.Domain.DomainObjects;
using FluentValidation;
using MediatR;

namespace CleanArch.Application.BaseMediator.Commands.BaseCreate
{
    public class BaseCreateCommand<TResponse> : IRequest<TResponse>
    {
        public dynamic Dto { get; private set; }

        public BaseCreateCommand(dynamic dto)
        {
            Dto = dto;
            //new BaseCreateCommandValidator<TDto>().ValidateAndThrow(this);
        }
    }
}

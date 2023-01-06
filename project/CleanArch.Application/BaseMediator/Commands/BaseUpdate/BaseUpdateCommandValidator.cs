using CleanArch.Domain.DomainObjects;
using FluentValidation;

namespace CleanArch.Application.BaseMediator.Commands.BaseUpdate
{
    public class BaseUpdateCommandValidator<T> : AbstractValidator<BaseUpdateCommand<T>>
            where T : DtoBase
    {
        public BaseUpdateCommandValidator()
        {
            // MY VALIDATIONS
        }
    }
}
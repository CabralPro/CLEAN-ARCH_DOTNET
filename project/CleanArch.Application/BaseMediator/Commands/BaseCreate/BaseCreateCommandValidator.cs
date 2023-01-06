using CleanArch.Domain.DomainObjects;
using FluentValidation;

namespace CleanArch.Application.BaseMediator.Commands.BaseCreate
{
    public class BaseCreateCommandValidator<T> : AbstractValidator<BaseCreateCommand<T>>
        where T : DtoBase
    {
        public BaseCreateCommandValidator()
        {
            // MY VALIDATIONS
        }
    }
}

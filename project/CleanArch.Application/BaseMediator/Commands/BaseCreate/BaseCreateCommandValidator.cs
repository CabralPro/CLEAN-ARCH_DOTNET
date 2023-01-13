using CleanArch.Domain.DomainObjects;
using FluentValidation;

namespace CleanArch.Application.BaseMediator.Commands.BaseCreate
{
    public class BaseCreateCommandValidator<TCommand> : AbstractValidator<TCommand>
    {
        public BaseCreateCommandValidator()
        {
            // MY VALIDATIONS
        }
    }
}

using FluentValidation;

namespace CleanArch.Application.BaseMediator.Commands.BaseDelete
{
    public class BaseDeleteCommandValidator<T> : AbstractValidator<BaseDeleteCommand<T>>
    {
        public BaseDeleteCommandValidator()
        {
            // MY VALIDATIONS
        }
    }
}

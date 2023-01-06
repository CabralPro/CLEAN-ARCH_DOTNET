using FluentValidation;

namespace CleanArch.Application.Features.BaseCrud.Commands.DeleteEntity
{
    public class DeleteEntityCommandValidator<T> : AbstractValidator<DeleteEntityCommand<T>>
    {
        public DeleteEntityCommandValidator()
        {
            // MY VALIDATIONS
        }
    }
}

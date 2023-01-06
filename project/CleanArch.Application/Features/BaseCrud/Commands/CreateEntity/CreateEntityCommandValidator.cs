using CleanArch.Domain.DomainObjects;
using FluentValidation;

namespace CleanArch.Application.Features.BaseCrud.Commands.CreateEntity
{
    public class CreateEntityCommandValidator<T> : AbstractValidator<CreateEntityCommand<T>>
        where T : EntityBase
    {
        public CreateEntityCommandValidator()
        {
            // MY VALIDATIONS
        }
    }
}

using CleanArch.Domain.DomainObjects;
using FluentValidation;

namespace CleanArch.Application.Features.BaseCrud.Commands.UpdateEntity
{
    public class UpdateEntityCommandValidator<T> : AbstractValidator<UpdateEntityCommand<T>>
            where T : EntityBase
    {
        public UpdateEntityCommandValidator()
        {
            // MY VALIDATIONS
        }
    }
}
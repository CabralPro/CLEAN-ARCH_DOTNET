using CleanArch.Domain.DomainObjects;
using FluentValidation;

namespace CleanArch.Application.BaseMediator.Commands.BaseUpdate
{
    public class BaseUpdateCommandValidator<TDto> : AbstractValidator<BaseUpdateCommand<TDto>>
            where TDto : DtoBase
    {
        public BaseUpdateCommandValidator()
        {
            // MY VALIDATIONS
        }
    }
}
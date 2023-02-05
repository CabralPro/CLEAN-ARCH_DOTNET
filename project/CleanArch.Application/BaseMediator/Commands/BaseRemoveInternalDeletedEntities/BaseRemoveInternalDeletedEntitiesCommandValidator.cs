using CleanArch.Domain.DomainObjects;
using FluentValidation;

namespace CleanArch.Application.BaseMediator.Commands.BaseRemoveInternalDeletedEntities
{
    public class BaseRemoveInternalDeletedEntitiesCommandValidator<T> : AbstractValidator<BaseRemoveInternalDeletedEntitiesCommand<T>>
        where T : DtoBase
    {
        public BaseRemoveInternalDeletedEntitiesCommandValidator()
        {
            // MY VALIDATIONS
        }
    }
}

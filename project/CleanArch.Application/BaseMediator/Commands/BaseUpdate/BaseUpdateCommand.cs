using CleanArch.Domain.DomainObjects;
using FluentValidation;
using MediatR;

namespace CleanArch.Application.BaseMediator.Commands.BaseUpdate
{
    public class BaseUpdateCommand<TDto> : IRequest<TDto>
        where TDto : DtoBase
    {
        public TDto Dto { get; private set; }

        public BaseUpdateCommand(TDto dto)
        {
            Dto = dto;
            new BaseUpdateCommandValidator<TDto>().ValidateAndThrow(this);
        }
    }
}

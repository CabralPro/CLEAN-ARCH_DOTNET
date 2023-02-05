using AutoMapper;
using CleanArch.Domain.DomainObjects;
using CleanArch.Domain.Interfaces;

namespace CleanArch.Application.BaseMediator.Commands.BaseCreate
{
    public abstract class CreateCommandHandler<TEntity, TCommand, TResponse, TDto>
        : BaseCreateCommandHandle<TEntity, TCommand, TResponse, TDto>
        where TEntity : EntityBase
        where TCommand : BaseCreateCommand<TResponse, TDto>
    {
        protected CreateCommandHandler(IBaseRepository<TEntity> repository, IMapper mapper) 
            : base(repository, mapper)
        {
        }
    }

    public abstract class CreateCommandHandler<TEntity, TCommand, TDto>
        : BaseCreateCommandHandle<TEntity, TCommand, TDto, TDto>
        where TEntity : EntityBase
        where TCommand : BaseCreateCommand<TDto, TDto>
    {
        protected CreateCommandHandler(IBaseRepository<TEntity> repository, IMapper mapper)
            : base(repository, mapper)
        {
        }
    }
}

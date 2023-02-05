using AutoMapper;
using CleanArch.Domain.DomainObjects;
using CleanArch.Domain.Interfaces;
using MediatR;

namespace CleanArch.Application.BaseMediator.Commands.BaseCreate
{
    public abstract class BaseCreateCommandHandle<TEntity, Tcommand, TResponse, TDto> : IRequestHandler<Tcommand, TResponse>
        where TEntity : EntityBase
        where Tcommand : BaseCreateCommand<TResponse, TDto>
    {
        public readonly IBaseRepository<TEntity> Repository;
        public readonly IMapper Mapper;

        public BaseCreateCommandHandle(
            IBaseRepository<TEntity> repository,
            IMapper mapper)
        {
            Repository = repository;
            Mapper = mapper;
        }

        public virtual async Task<TResponse> Handle(Tcommand request, CancellationToken cancellationToken)
        {
            var entity = Mapper.Map<TEntity>(request.Dto);
            var updatedEntity = await Repository.AddAsync(entity, cancellationToken);
            return Mapper.Map<TResponse>(updatedEntity);
        }
    }
}

using AutoMapper;
using CleanArch.Domain.DomainObjects;
using CleanArch.Domain.Interfaces;
using MediatR;

namespace CleanArch.Application.BaseMediator.Commands.BaseUpdate
{
    public class BaseUpdateCommandHandle<TEntity, TDto, TCommand> : IRequestHandler<TCommand, TDto>
        where TEntity : EntityBase
        where TDto : DtoBase
        where TCommand : BaseUpdateCommand<TDto>
    {

        public readonly IBaseRepository<TEntity> Repository;
        public readonly IMapper Mapper;

        public BaseUpdateCommandHandle(
            IBaseRepository<TEntity> repository,
            IMapper mapper)
        {
            Repository = repository;
            Mapper = mapper;
        }

        public virtual async Task<TDto> Handle(TCommand request, CancellationToken cancellationToken)
        {
            var entity = Mapper.Map<TEntity>(request.Dto);
            var updatedEntity = await Repository.UpdateAsync(entity, cancellationToken);
            return Mapper.Map<TDto>(updatedEntity);
        }
    }
}

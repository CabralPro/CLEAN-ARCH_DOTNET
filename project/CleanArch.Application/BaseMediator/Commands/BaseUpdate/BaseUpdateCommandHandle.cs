using AutoMapper;
using CleanArch.Domain.DomainObjects;
using CleanArch.Domain.Interfaces;
using MediatR;

namespace CleanArch.Application.BaseMediator.Commands.BaseUpdate
{
    public class BaseUpdateCommandHandle<T1, T2> : IRequestHandler<BaseUpdateCommand<T2>, T2>
        where T1 : EntityBase
        where T2 : DtoBase
    {

        public readonly IBaseRepository<T1> Repository;
        public readonly IMapper Mapper;

        public BaseUpdateCommandHandle(
            IBaseRepository<T1> repository,
            IMapper mapper)
        {
            Repository = repository;
            Mapper = mapper;
        }

        public virtual async Task<T2> Handle(BaseUpdateCommand<T2> request, CancellationToken cancellationToken)
        {
            var entity = Mapper.Map<T1>(request.Dto);
            var updatedEntity = await Repository.UpdateAsync(entity, cancellationToken);
            return Mapper.Map<T2>(updatedEntity);
        }

    }
}

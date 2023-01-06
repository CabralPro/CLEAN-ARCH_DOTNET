using AutoMapper;
using CleanArch.Domain.DomainObjects;
using CleanArch.Domain.Interfaces;
using MediatR;

namespace CleanArch.Application.BaseMediator.Commands.BaseCreate
{
    public class BaseCreateCommandHandle<T1, T2> : IRequestHandler<BaseCreateCommand<T2>, T2>
        where T1 : EntityBase
        where T2 : DtoBase
    {
        public readonly IBaseRepository<T1> Repository;
        public readonly IMapper Mapper;

        public BaseCreateCommandHandle(
            IBaseRepository<T1> repository,
            IMapper mapper)
        {
            Repository = repository;
            Mapper = mapper;
        }

        public virtual async Task<T2> Handle(BaseCreateCommand<T2> request, CancellationToken cancellationToken)
        {
            var entity = Mapper.Map<T1>(request.Dto);
            var updatedEntity = await Repository.AddAsync(entity, cancellationToken);
            return Mapper.Map<T2>(updatedEntity);
        }

    }
}

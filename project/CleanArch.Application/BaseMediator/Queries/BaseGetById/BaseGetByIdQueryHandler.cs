using AutoMapper;
using CleanArch.Domain.DomainObjects;
using CleanArch.Domain.Interfaces;
using MediatR;

namespace CleanArch.Application.BaseMediator.Queries.BaseGetById
{
    public class BaseGetByIdQueryHandler<T1, T2> : IRequestHandler<BaseGetByIdQuery<T2>, T2>
        where T1 : EntityBase
        where T2 : DtoBase
    {
        private readonly IBaseRepository<T1> _repository;
        private readonly IMapper _mapper;

        public BaseGetByIdQueryHandler(IBaseRepository<T1> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public virtual async Task<T2> Handle(BaseGetByIdQuery<T2> request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.EntityId, cancellationToken);
            return _mapper.Map<T2>(entity);
        }

    }
}

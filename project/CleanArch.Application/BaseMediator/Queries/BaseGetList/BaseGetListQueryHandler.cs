using AutoMapper;
using CleanArch.Domain.DomainObjects;
using CleanArch.Domain.Interfaces;
using MediatR;

namespace CleanArch.Application.BaseMediator.Queries.BaseGetList
{
    public class BaseGetListQueryHandler<T1, T2> : IRequestHandler<BaseGetListQuery<T2>, (IEnumerable<T2>, int)>
        where T1 : EntityBase
        where T2 : DtoBase
    {
        private readonly IBaseRepository<T1> _repository;
        private readonly IMapper _mapper;

        public BaseGetListQueryHandler(IBaseRepository<T1> clientRepository, IMapper mapper)
        {
            _repository = clientRepository;
            _mapper = mapper;
        }

        public virtual async Task<(IEnumerable<T2>, int)> Handle(BaseGetListQuery<T2> request, CancellationToken cancellationToken)
        {
            var clientList = await _repository.ListAsync(request.Page, request.Size, cancellationToken);
            var clientListDto = _mapper.Map<IEnumerable<T2>>(clientList);
            var totalEntitys = await _repository.CountAsync(cancellationToken);
            return (clientListDto, totalEntitys);
        }

    }
}

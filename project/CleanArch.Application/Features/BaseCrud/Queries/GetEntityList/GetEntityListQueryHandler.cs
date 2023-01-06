using AutoMapper;
using CleanArch.Domain.DomainObjects;
using CleanArch.Domain.Interfaces;
using MediatR;

namespace CleanArch.Application.Features.BaseCrud.Queries.GetEntityList
{
    public class GetEntityListQueryHandler<T1, T2> : IRequestHandler<GetEntityListQuery<T2>, (IEnumerable<T2>, int)>
        where T1 : EntityBase
        where T2 : DtoBase
    {
        private readonly IBaseRepository<T1> _repository;
        private readonly IMapper _mapper;

        public GetEntityListQueryHandler(IBaseRepository<T1> clientRepository, IMapper mapper)
        {
            _repository = clientRepository;
            _mapper = mapper;
        }

        public async Task<(IEnumerable<T2>, int)> Handle(GetEntityListQuery<T2> request, CancellationToken cancellationToken)
        {
            var clientList = await _repository.ListAsync(request.Page, request.Size, cancellationToken);
            var clientListDto = _mapper.Map<IEnumerable<T2>>(clientList);
            var totalEntitys = await _repository.CountAsync(cancellationToken);
            return (clientListDto, totalEntitys);
        }

    }
}

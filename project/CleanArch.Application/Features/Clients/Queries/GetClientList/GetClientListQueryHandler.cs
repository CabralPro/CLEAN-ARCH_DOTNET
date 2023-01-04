using AutoMapper;
using CleanArch.Application.Dtos;
using CleanArch.Domain.Interfaces;
using MediatR;

namespace CleanArch.Application.Features.Clients.Queries.GetClientList
{
    public class GetClientListQueryHandler : IRequestHandler<GetClientListQuery, (IEnumerable<ClientDto>, int)>
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;

        public GetClientListQueryHandler(IClientRepository clientRepository, IMapper mapper)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
        }

        public async Task<(IEnumerable<ClientDto>, int)> Handle(GetClientListQuery request, CancellationToken cancellationToken)
        {
            var clientList = await _clientRepository.ListAsync(request.Page, request.Size, cancellationToken);
            var clientListDto = _mapper.Map<IEnumerable<ClientDto>>(clientList);
            var totalClients = await _clientRepository.CountAsync(cancellationToken);
            return (clientListDto, totalClients);
        }

    }
}

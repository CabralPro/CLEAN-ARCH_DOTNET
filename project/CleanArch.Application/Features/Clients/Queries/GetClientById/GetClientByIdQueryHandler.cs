using AutoMapper;
using CleanArch.Application.Dtos;
using CleanArch.Domain.Interfaces;
using MediatR;

namespace CleanArch.Application.Features.Clients.Queries.GetClientById
{
    public class GetClientByIdQueryHandler : IRequestHandler<GetClientByIdQuery, ClientDto>
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;

        public GetClientByIdQueryHandler(IClientRepository clientRepository, IMapper mapper)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
        }

        public async Task<ClientDto> Handle(GetClientByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _clientRepository.GetByIdAsync(request.ClientId, cancellationToken);
            return _mapper.Map<ClientDto>(entity);
        }
    }
}

using AutoMapper;
using CleanArch.Application.Dtos;
using CleanArch.Application.Interfaces;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;

namespace CleanArch.Application.Services
{
    public class ClientService : BaseService<Client, ClientDto>, IClientService
    {
        public ClientService(IBaseRepository<Client> repository, IMapper mapper)
            : base(repository, mapper)
        { }
    }
}

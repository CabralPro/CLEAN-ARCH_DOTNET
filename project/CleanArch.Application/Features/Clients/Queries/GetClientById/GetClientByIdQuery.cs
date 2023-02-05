using CCleanArch.Application.Dtos.Clients;
using CleanArch.Application.BaseMediator.Queries.BaseGetById;

namespace CleanArch.Application.Features.Clients.Queries.GetClientById
{
    public class GetClientByIdQuery : BaseGetByIdQuery<ClientDto>
    {
        public GetClientByIdQuery(Guid entityId)
            : base(entityId)
        { }
    }
}

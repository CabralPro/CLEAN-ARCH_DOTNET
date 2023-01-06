using CleanArch.Application.Dtos;
using CleanArch.Application.Features.BaseCrud.Queries.GetEntityById;

namespace CleanArch.Application.Features.Clients.Queries.GetClientById
{
    public class GetClientByIdQuery : GetEntityByIdQuery<ClientDto>
    {
        public GetClientByIdQuery(Guid entityId)
            : base(entityId)
        { }
    }
}

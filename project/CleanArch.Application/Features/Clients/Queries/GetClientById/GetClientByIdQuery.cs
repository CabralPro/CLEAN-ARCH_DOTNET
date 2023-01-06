using CleanArch.Application.BaseMediator.Queries.BaseGetById;
using CleanArch.Application.Dtos;

namespace CleanArch.Application.Features.Clients.Queries.GetClientById
{
    public class GetClientByIdQuery : BaseGetByIdQuery<ClientDto>
    {
        public GetClientByIdQuery(Guid entityId)
            : base(entityId)
        { }
    }
}

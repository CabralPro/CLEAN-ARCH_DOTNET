using CleanArch.Domain.DomainObjects;
using MediatR;

namespace CleanArch.Application.Features.BaseCrud.Queries.GetEntityById
{
    public class GetEntityByIdQuery<T> : IRequest<T>
        where T : DtoBase
    {
        public Guid EntityId { get; private set; }

        public GetEntityByIdQuery(Guid entityId)
        {
            EntityId = entityId;
        }
    }
}

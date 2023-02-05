using CleanArch.Domain.DomainObjects;
using MediatR;

namespace CleanArch.Application.BaseMediator.Queries.BaseGetById
{
    public class BaseGetByIdQuery<T> : IRequest<T>
        where T : DtoBase
    {
        public Guid EntityId { get; private set; }

        public BaseGetByIdQuery(Guid entityId)
        {
            EntityId = entityId;
        }
    }
}

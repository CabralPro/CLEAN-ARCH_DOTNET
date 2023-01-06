using CleanArch.Domain.DomainObjects;
using MediatR;

namespace CleanArch.Application.Features.BaseCrud.Queries.GetEntityList
{
    public class GetEntityListQuery<T> : IRequest<(IEnumerable<T>, int)>
        where T : DtoBase
    {
        public int Page { get; private set; }
        public int Size { get; private set; }

        public GetEntityListQuery(int page, int size)
        {
            Page = page;
            Size = size;
        }
    }
}

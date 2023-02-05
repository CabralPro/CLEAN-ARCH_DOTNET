using CleanArch.Domain.DomainObjects;
using MediatR;

namespace CleanArch.Application.BaseMediator.Queries.BaseGetList
{
    public class BaseGetListQuery<T> : IRequest<(IEnumerable<T>, int)>
        where T : DtoBase
    {
        public int Page { get; private set; }
        public int Size { get; private set; }

        public BaseGetListQuery(int page, int size)
        {
            Page = page;
            Size = size;
        }
    }
}

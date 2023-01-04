using CleanArch.Application.Dtos;
using MediatR;

namespace CleanArch.Application.Features.Clients.Queries.GetClientList
{
    public class GetClientListQuery : IRequest<(IEnumerable<ClientDto>, int)>
    {
        public int Page { get; private set; }
        public int Size { get; private set; }

        public GetClientListQuery(int page, int size)
        {
            Page = page;
            Size = size;
        }
    }
}

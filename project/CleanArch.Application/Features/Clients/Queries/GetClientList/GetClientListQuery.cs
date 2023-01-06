using CleanArch.Application.Dtos;
using CleanArch.Application.Features.BaseCrud.Queries.GetEntityList;

namespace CleanArch.Application.Features.Clients.Queries.GetClientList
{
    public class GetClientListQuery : GetEntityListQuery<ClientDto>
    {
        public GetClientListQuery(int page, int size)
            : base(page, size)
        { }
    }
}

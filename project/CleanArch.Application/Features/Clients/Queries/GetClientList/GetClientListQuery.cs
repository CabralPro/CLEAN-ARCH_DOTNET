using CCleanArch.Application.Dtos.Clients;
using CleanArch.Application.BaseMediator.Queries.BaseGetList;

namespace CleanArch.Application.Features.Clients.Queries.GetClientList
{
    public class GetClientListQuery : BaseGetListQuery<ClientDto>
    {
        public GetClientListQuery(int page, int size)
            : base(page, size)
        { }
    }
}

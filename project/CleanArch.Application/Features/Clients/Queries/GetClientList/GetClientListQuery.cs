using CleanArch.Application.BaseMediator.Queries.BaseGetList;
using CleanArch.Application.Dtos;

namespace CleanArch.Application.Features.Clients.Queries.GetClientList
{
    public class GetClientListQuery : BaseGetListQuery<ClientDto>
    {
        public GetClientListQuery(int page, int size)
            : base(page, size)
        { }
    }
}

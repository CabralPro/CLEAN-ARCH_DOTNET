using CleanArch.Application.BaseMediator.Commands.BaseDelete;
using CleanArch.Domain.Entities;

namespace CleanArch.Application.Features.Clients.Commands.DeleteClient
{
    public class DeleteClientCommandValidator : BaseDeleteCommandValidator<Client>
    {
        public DeleteClientCommandValidator()
        {
            // MY VALIDATIONS
        }
    }
}

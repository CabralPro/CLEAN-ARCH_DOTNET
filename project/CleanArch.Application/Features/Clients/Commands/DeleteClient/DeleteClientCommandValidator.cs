using CleanArch.Application.Features.BaseCrud.Commands.DeleteEntity;
using CleanArch.Domain.Entities;

namespace CleanArch.Application.Features.Clients.Commands.DeleteClient
{
    public class DeleteClientCommandValidator : DeleteEntityCommandValidator<Client>
    {
        public DeleteClientCommandValidator()
        {
            // MY VALIDATIONS
        }
    }
}

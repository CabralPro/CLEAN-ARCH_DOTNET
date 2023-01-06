using CleanArch.Application.Features.BaseCrud.Commands.CreateEntity;
using CleanArch.Domain.Entities;

namespace CleanArch.Application.Features.Clients.Commands.CreateClient
{
    public class CreateClientCommandValidator : CreateEntityCommandValidator<Client>
    {
        public CreateClientCommandValidator()
        {
            // MY VALIDATIONS
        }
    }
}

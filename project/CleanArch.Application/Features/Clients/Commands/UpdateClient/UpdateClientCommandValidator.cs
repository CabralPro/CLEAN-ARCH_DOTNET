using CleanArch.Application.Features.BaseCrud.Commands.UpdateEntity;
using CleanArch.Domain.Entities;

namespace CleanArch.Application.Features.Clients.Commands.UpdateClient
{
    public class UpdateClientCommandValidator : UpdateEntityCommandValidator<Client>
    {
        public UpdateClientCommandValidator()
        {
            // MY VALIDATIONS
        }
    }
}
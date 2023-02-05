using CCleanArch.Application.Dtos.Clients;
using CleanArch.Application.BaseMediator.Commands.BaseUpdate;

namespace CleanArch.Application.Features.Clients.Commands.UpdateClient
{
    public class UpdateClientCommandValidator : BaseUpdateCommandValidator<ClientDto>
    {
        public UpdateClientCommandValidator()
        {
            // MY VALIDATIONS
        }
    }
}
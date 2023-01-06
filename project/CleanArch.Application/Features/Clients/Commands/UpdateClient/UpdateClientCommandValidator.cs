using CleanArch.Application.BaseMediator.Commands.BaseUpdate;
using CleanArch.Application.Dtos;

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
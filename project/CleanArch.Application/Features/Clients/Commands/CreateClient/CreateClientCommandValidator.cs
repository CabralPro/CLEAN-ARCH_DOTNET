using CleanArch.Application.BaseMediator.Commands.BaseCreate;
using CleanArch.Application.Dtos;

namespace CleanArch.Application.Features.Clients.Commands.CreateClient
{
    public class CreateClientCommandValidator : BaseCreateCommandValidator<ClientDto>
    {
        public CreateClientCommandValidator()
        {
            // MY VALIDATIONS
        }
    }
}

using CleanArch.Application.BaseMediator.Commands.BaseCreate;
using CleanArch.Application.Dtos;
using FluentValidation;

namespace CleanArch.Application.Features.Clients.Commands.CreateClient
{
    public class CreateClientCommandValidator : BaseCreateCommandValidator<CreateClientCommand>
    {
        public CreateClientCommandValidator()
        {
        }
    }
}

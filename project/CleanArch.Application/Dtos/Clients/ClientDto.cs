using CleanArch.Application.Dtos;
using CleanArch.Domain.DomainObjects;
using FluentValidation;
using System.Text.Json.Serialization;

namespace CCleanArch.Application.Dtos.Clients
{
    public class ClientDto : DtoBase
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("address")]
        public AddressDto Address { get; set; }

        [JsonPropertyName("bankAccounts")]
        public IList<BankAccountDto> BankAccounts { get; set; }

        public ClientDto(string name, AddressDto address, IList<BankAccountDto> bankAccounts)
        {
            Name = name;
            Address = address;
            BankAccounts = bankAccounts;
            Validate();
        }

        public override void Validate()
        {
            new ClientDtoValidator().ValidateAndThrow(this);
        }
    }

    public class ClientDtoValidator : AbstractValidator<ClientDto>
    {
        public ClientDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Address).NotEmpty();
            RuleFor(x => x.BankAccounts).NotEmpty();
        }
    }
}

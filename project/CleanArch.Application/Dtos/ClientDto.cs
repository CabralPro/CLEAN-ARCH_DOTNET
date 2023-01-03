
using CleanArch.Domain.DomainObjects;
using System.Text.Json.Serialization;

namespace CleanArch.Application.Dtos
{
    public class ClientDto : DtoBase
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("address")]
        public AddressDto Address { get; set; }

        [JsonPropertyName("bankAccounts")]
        public IList<BankAccountDto> BankAccounts { get; set; }
    }
}

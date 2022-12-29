
using CleanArch.Domain.DomainObjects;
using System.Text.Json.Serialization;

namespace CleanArch.Application.Dtos
{
    public class ClientDto : Dto
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("residentialAddress")]
        public AddressDto ResidentialAddress { get; set; }

        [JsonPropertyName("businessAddress")]
        public AddressDto BusinessAddress { get; set; }

        [JsonPropertyName("bankAccounts")]
        public IList<BankAccountDto> BankAccounts { get; set; }
    }
}

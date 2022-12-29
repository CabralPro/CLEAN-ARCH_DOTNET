
using CleanArch.Domain.DomainObjects;
using System.Text.Json.Serialization;

namespace CleanArch.Application.Dtos
{
    public class AddressDto : Dto
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("street")]
        public string Street { get; set; }

        [JsonPropertyName("number")]
        public string Number { get; set; }
    }
}

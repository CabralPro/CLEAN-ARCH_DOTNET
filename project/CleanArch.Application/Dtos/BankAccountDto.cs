
using CleanArch.Domain.DomainObjects;
using System.Text.Json.Serialization;

namespace CleanArch.Application.Dtos
{
    public class BankAccountDto : DtoBase
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("accountData")]
        public string AccountData { get; set; }
    }
}

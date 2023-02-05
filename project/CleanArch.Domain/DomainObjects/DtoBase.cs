
using System.Text.Json.Serialization;

namespace CleanArch.Domain.DomainObjects
{
    public abstract class DtoBase
    {
        [JsonPropertyOrder(-1)]
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        public abstract void Validate();
    }
}

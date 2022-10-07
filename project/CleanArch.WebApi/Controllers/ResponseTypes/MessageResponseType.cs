using System.Text.Json.Serialization;

namespace CleanArch.WebApi.Controllers.ResponseTypes
{
    public class MessageResponseType
    {
        [JsonPropertyName("message")]
        public string Message { get; set; }
    }
}

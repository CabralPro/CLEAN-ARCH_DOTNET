using System.Text.Json.Serialization;

namespace CleanArch.WebApi.Controllers.ResponseTypes
{
    public class ErrorResponseType
    {
        [JsonPropertyName("error")]
        public string Error { get; set; }
    }
}

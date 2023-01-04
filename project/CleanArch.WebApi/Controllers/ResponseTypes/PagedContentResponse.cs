using System.Text.Json.Serialization;

namespace CleanArch.WebApi.Controllers.ResponseTypes
{
    public class PagedContentResponse<T>
    {
        [JsonPropertyName("items")]
        public IEnumerable<T> Items { get; set; }
        [JsonPropertyName("total")]
        public int Total { get; set; }
    }
}

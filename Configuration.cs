using System.Text.Json;
using System.Text.Json.Serialization;

namespace History
{
    public class Configuration
    {
        [JsonPropertyName("token")]
        public string Token { get; set; }
    }
}
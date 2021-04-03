using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace History
{
    public class Server
    {
        [JsonPropertyName("name")]
        string Name { get; set; }

        [JsonPropertyName("type")]
        string Type { get; set; }
    }
}
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace History
{
    public class Embed
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }


        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("t")]
        public string T { get; set; }
    }
}
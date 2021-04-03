using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace History
{
    public class Channel
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("server")]
        public int ServerIndex { get; set; }
    }
}
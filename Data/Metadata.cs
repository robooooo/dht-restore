using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace History
{
    public class Metadata
    {
        [JsonPropertyName("users")]
        public Dictionary<string, User> Users { get; set; }

        [JsonPropertyName("userindex")]
        public List<string> UserIndex { get; set; }

        [JsonPropertyName("servers")]
        public List<Server> Servers { get; set; }


        [JsonPropertyName("channels")]
        public Dictionary<string, Channel> Channels { get; set; }
    }
}
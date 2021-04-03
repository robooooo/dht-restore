using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace History
{
    public class Message
    {
        [JsonPropertyName("u")]
        public int UserIndex { get; set; }

        [JsonPropertyName("t")]
        public ulong Timestamp { get; set; }

        [JsonPropertyName("m")]
        public string Content { get; set; }

        [JsonPropertyName("a")]
        public List<Attatchment> Attatchments { get; set; }

        [JsonPropertyName("e")]
        public List<Embed> Embeds { get; set; }
    }
}
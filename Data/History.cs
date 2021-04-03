using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace History
{
    public class History
    {
        [JsonPropertyName("meta")]
        public Metadata Meta { get; set; }

        [JsonPropertyName("data")]
        /// k1 : (k2 : v) :: ChannelId : (MessageID : Message)
        public Dictionary<string, Dictionary<string, Message>> Data { get; set; }
    }
}
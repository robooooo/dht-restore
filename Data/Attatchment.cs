using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace History
{
    public class Attatchment
    {
        [JsonPropertyName("url")]
        public string Url { get; set; }
    }
}
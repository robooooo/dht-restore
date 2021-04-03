using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace History
{
    public class User
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("avatar")]
        public string Avatar { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace EspacioPersonaje
{
    public class ChampionData
    {
        [JsonPropertyName("data")]
        public Dictionary<string, Champion> Data { get; set; }
    }

    public class Champion
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("tags")]
        public List<string> Tags { get; set; }
    }
}

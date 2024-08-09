using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

// Esta clase representa la estructura de los datos de los campeones que se recibirán desde la API.
namespace EspacioPersonaje
{
    public class ChampionData
    {
        // La propiedad `Data` es un diccionario que contiene información sobre los campeones.
        [JsonPropertyName("data")]
        public Dictionary<string, Champion> Data { get; set; }
    }

// Esta clase representa los detalles de un campeón específico.
    public class Champion
    {
        // La propiedad `Name` almacena el nombre del campeón.
        [JsonPropertyName("name")]
        public string Name { get; set; }

        // La propiedad `Tags` es una lista de strings que contiene los roles o tipos a los que pertenece el campeón (como "Mage", "Marksman", etc.).
        [JsonPropertyName("tags")]
        public List<string> Tags { get; set; }
    }
}

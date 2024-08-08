using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace EspacioPersonaje
{
    public class ControlApi
    {
        private const string Url = "https://ddragon.leagueoflegends.com/cdn/14.13.1/data/en_US/champion.json";

        public async Task<Dictionary<string, string>> ObtenerDatosPersonajesAsync()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string json = await client.GetStringAsync(Url);
                    var championData = JsonSerializer.Deserialize<ChampionData>(json);

                    var personajes = new Dictionary<string, string>();
                    foreach (var champion in championData.Data)
                    {
                        // Usamos el primer tipo para simplificar
                        string tipo = champion.Value.Tags.Count > 0 ? champion.Value.Tags[0] : "Desconocido";
                        personajes.Add(champion.Value.Name, tipo);
                    }

                    return personajes;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener o procesar los datos: {ex.Message}");
                return new Dictionary<string, string>();
            }
        }
    }
}

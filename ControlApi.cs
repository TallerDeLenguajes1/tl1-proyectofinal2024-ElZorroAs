using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace EspacioPersonaje
{
    public class ControlApi
    {
        // URL de la API para obtener los datos de los campeones
        private const string Url = "https://ddragon.leagueoflegends.com/cdn/14.13.1/data/en_US/champion.json";

        // Método asíncrono para obtener datos de campeones desde la API
        public async Task<Dictionary<string, string>> ObtenerDatosPersonajesAsync()
        {
            try
            {
                // Crear una instancia de HttpClient para enviar solicitudes HTTP
                using (HttpClient client = new HttpClient())
                {
                    // Realiza una solicitud HTTP GET para obtener los datos en formato JSON
                    string json = await client.GetStringAsync(Url);

                    // Deserializa el JSON en un objeto ChampionData
                    var championData = JsonSerializer.Deserialize<ChampionData>(json);

                    // Crear un diccionario para almacenar los nombres y tipos de campeones
                    var personajes = new Dictionary<string, string>();

                    // Recorre cada campeón en los datos deserializados
                    foreach (var champion in championData.Data)
                    {
                        // Usamos el primer tipo disponible para simplificar. Si no hay tipos, asignamos "Desconocido"
                        string tipo = champion.Value.Tags.Count > 0 ? champion.Value.Tags[0] : "Desconocido";
                        personajes.Add(champion.Value.Name, tipo);
                    }

                    // Retorna el diccionario con los nombres y tipos de campeones
                    return personajes;
                }
            }
            catch (Exception ex)
            {
                // Muestra un mensaje de error en caso de que ocurra una excepción
                Console.WriteLine($"Error al obtener o procesar los datos: {ex.Message}");
                // Retorna un diccionario vacío en caso de error
                return new Dictionary<string, string>();
            }
        }
    }
}
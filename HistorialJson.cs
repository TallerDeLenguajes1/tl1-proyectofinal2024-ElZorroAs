//==============================================================================================================================//
/*
2ra Parte Persistencia de datos (Lectura y guardado de Json)
*/
//==============================================================================================================================//

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace EspacioPersonaje
{
    // Clase que representa la información sobre un ganador.
    // Almacena el personaje ganador y la fecha en que ganó.
    public class Ganador
    {
        // Propiedad que almacena el personaje que ganó.
        public Personaje personajeGanador { get; set; }

        // Propiedad que almacena la fecha de victoria en formato de cadena.
        public string fechaVictoria { get; set; }

        // Constructor por defecto.
        public Ganador() { }

        // Constructor que inicializa las propiedades con valores específicos.
        public Ganador(Personaje ganador, string victoria)
        {
            personajeGanador = ganador;
            fechaVictoria = victoria;
        }
    }


    /*
    1) Armar una clase llamada HistorialJson para guardar y leer desde un archivo Json
    */
    // Clase que gestiona el almacenamiento y recuperación de datos de ganadores en un archivo JSON.
    public class HistorialJson
    {
        /*
        2) Crear un método llamado GuardarGanador que reciba el personaje ganador e
        información relevante de las partidas, el nombre del archivo y lo guarde en formato Json.
        */
        public void GuardarGanador(Personaje ganador, DateTime fecha, string nombreArchivo)
        {
            try
            {
                // Verifica si el archivo existe. Si existe, lee los ganadores actuales, de lo contrario, crea una nueva lista.
                List<Ganador> ganadores = Existe(nombreArchivo)
                    ? LeerGanadores(nombreArchivo)
                    : new List<Ganador>();

                // Convierte la fecha de victoria a una cadena en formato "yyyy-MM-dd".
                string fechaFormateada = fecha.ToString("yyyy-MM-dd");

                // Agrega un nuevo registro de ganador a la lista.
                ganadores.Add(new Ganador(ganador, fechaFormateada));

                // Configura las opciones para la serialización JSON para hacer el archivo legible.
                var opciones = new JsonSerializerOptions { WriteIndented = true };

                // Abre un archivo para escritura y guarda la lista de ganadores en formato JSON.
                using (var archivo = new FileStream(nombreArchivo, FileMode.Create))
                {
                    using (var strWriter = new StreamWriter(archivo))
                    {
                        // Serializa la lista de ganadores a JSON y la escribe en el archivo.
                        string json = JsonSerializer.Serialize(ganadores, opciones);
                        strWriter.WriteLine(json);
                    }
                }
                Console.WriteLine($"Datos guardados en '{nombreArchivo}'.");
            }
            catch (Exception e)
            {
                // Captura y muestra errores que puedan ocurrir durante el proceso de guardado.
                Console.WriteLine($"Error al guardar el archivo '{nombreArchivo}': {e.Message}");
            }
        }

        /*
        3) Crear un método llamado LeerGanadores que reciba un nombre de archivo y retorne la
        lista de personajes ganadores e información relevante incluidos en el Json.
        */
        public List<Ganador> LeerGanadores(string nombreArchivo)
        {
            List<Ganador> ganadores = new List<Ganador>();
            try
            {
                // Abre el archivo para lectura y deserializa el contenido JSON a una lista de ganadores.
                using (var archivoOpen = new FileStream(nombreArchivo, FileMode.Open))
                {
                    using (var strReader = new StreamReader(archivoOpen))
                    {
                        // Lee todo el contenido del archivo y lo deserializa desde JSON.
                        string json = strReader.ReadToEnd();
                        ganadores = JsonSerializer.Deserialize<List<Ganador>>(json);
                    }
                }
            }
            catch (FileNotFoundException)
            {
                // Maneja el caso en que el archivo no se encuentra.
                Console.WriteLine(
                    $"Archivo '{nombreArchivo}' no encontrado. No hay ganadores registrados."
                );
            }
            catch (JsonException jsonEx)
            {
                // Maneja errores en la deserialización del archivo JSON.
                Console.WriteLine(
                    $"Error al deserializar el archivo '{nombreArchivo}': {jsonEx.Message}"
                );
            }
            catch (Exception e)
            {
                // Maneja cualquier otro error que pueda ocurrir.
                Console.WriteLine($"Error al leer el archivo '{nombreArchivo}': {e.Message}");
            }
            return ganadores; // Retorna la lista de ganadores (vacía si ocurrió un error).
        }

        /*
        4) Crear un método llamado Existe que reciba un nombre de archivo y que retorne un True
        si existe y tiene datos o False en caso contrario. 
        */
        public bool Existe(string nombreArchivo)
        {
            try
            {
                // Verifica si el archivo existe y si su tamaño es mayor que cero.
                return File.Exists(nombreArchivo) && new FileInfo(nombreArchivo).Length > 0;
            }
            catch (Exception e)
            {
                // Maneja errores que puedan ocurrir al verificar el archivo.
                Console.WriteLine($"Error al verificar el archivo '{nombreArchivo}': {e.Message}");
                return false;
            }
        }
    }
}
//==============================================================================================================================//
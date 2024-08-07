//==============================================================================================================================//
/*
1ra Parte Persistencia de datos (Lectura y guardado de Json):
*/
//==============================================================================================================================//

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
namespace EspacioPersonaje;

/*
1) Armar una clase llamada PersonajesJson para guardar y leer desde un archivo Json
*/
public class PersonajeJson
{
    /*
    2) Crear un método llamado GuardarPersonajes que reciba una lista de personajes, el
    nombre del archivo y lo guarde en formato Json.
    */
    public static void GuardarPersonajes(List<Personaje> personajes, string nombreArchivo)
    {
        try
        {
            var opciones = new JsonSerializerOptions { WriteIndented = true };
            using (var archivo = new FileStream(nombreArchivo, FileMode.Create))
            {
                using (var strWriter = new StreamWriter(archivo))
                {
                    string json = JsonSerializer.Serialize(personajes, opciones);
                    strWriter.WriteLine(json);
                    strWriter.Flush();
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error al guardar el archivo '{nombreArchivo}': {e.Message}");
        }
    }
    /*
    3) Crear un método llamado LeerPersonajes que reciba un nombre de archivo y retorne la
    lista de personajes incluidos en el son. 
    */
    public static List<Personaje> LeerPersonajes(string nombreArchivo)
    {
        List<Personaje> personajes = new List<Personaje>();
        try
        {
            using (var archivoOpen = new FileStream(nombreArchivo, FileMode.Open))
            {
                using (var strReader = new StreamReader(archivoOpen))
                {
                    string json = strReader.ReadToEnd();
                    personajes = JsonSerializer.Deserialize<List<Personaje>>(json);
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error al leer el archivo '{nombreArchivo}': {e.Message}");
        }
        return personajes;
    }
    /*
    4) Crear un método llamado Existe que reciba un nombre de archivo y que retorne un True
    si existe y tiene datos o False en caso contrario. 
    */
    public static bool Existe(string nombreArchivo)
    {
        try
        {
            return File.Exists(nombreArchivo) && new FileInfo(nombreArchivo).Length > 0;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error al verificar el archivo '{nombreArchivo}': {e.Message}");
            return false;
        }
    }
}
//==============================================================================================================================//
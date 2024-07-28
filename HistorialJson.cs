//==============================================================================================================================//
/*
2ra Parte Persistencia de datos (Lectura y guardado de Json)
*/
//==============================================================================================================================//

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
namespace EspacioPersonaje;
/*
1) Armar una clase llamada HistorialJson para guardar y leer desde un archivo Json
*/
public class HistorialJson
{
    /*
    2) Crear un método llamado GuardarGanador que reciba el personaje ganador e
    información relevante de las partidas, el nombre del archivo y lo guarde en formato Json.
    */
    public void GuardarGanador(Personaje ganador, DateTime fecha, string informacion, string nombreArchivo)
    {
        try
        {
            List<Personaje> ganadores = Existe(nombreArchivo) ? LeerGanadores(nombreArchivo) : new List<Personaje>();
            ganadores.Add(ganador);

            var opciones = new JsonSerializerOptions { WriteIndented = true };
            using (var archivo = new FileStream(nombreArchivo, FileMode.Create))
            {
                using (var strWriter = new StreamWriter(archivo))
                {
                    string json = JsonSerializer.Serialize(ganadores, opciones);
                    strWriter.WriteLine(json);
                }
            }
            Console.WriteLine($"Datos guardados en '{nombreArchivo}'.");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error al guardar el archivo '{nombreArchivo}': {e.Message}");
        }
    }

    /*
    3) Crear un método llamado LeerGanadores que reciba un nombre de archivo y retorne la
    lista de personajes ganadores e información relevante incluidos en el Json.
    */
    public List<Personaje> LeerGanadores(string nombreArchivo)
    {
        List<Personaje> ganadores = new List<Personaje>();
        try
        {
            using (var archivoOpen = new FileStream(nombreArchivo, FileMode.Open))
            {
                using (var strReader = new StreamReader(archivoOpen))
                {
                    string json = strReader.ReadToEnd();
                    ganadores = JsonSerializer.Deserialize<List<Personaje>>(json);
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error al leer el archivo '{nombreArchivo}': {e.Message}");
        }
        return ganadores;
    }
    /*
    4) Crear un método llamado Existe que reciba un nombre de archivo y que retorne un True
    si existe y tiene datos o False en caso contrario. 
    */
    public bool Existe(string nombreArchivo)
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
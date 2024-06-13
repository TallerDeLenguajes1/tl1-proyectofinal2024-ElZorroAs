using System;

namespace Personajes
{
//==============================================================================================================================//
/*
Prueba de terminal:
*/
//==============================================================================================================================//
    class Program
    {
        static void Main(string[] args)
        {
            // Crear instancia de Datos
            Datos datosPersonaje = new Datos("Humano", "John", "El valiente", new DateTime(1990, 5, 15), 30);

            // Crear instancia de Caracteristicas
            Caracteristicas caracteristicasPersonaje = new Caracteristicas(5, 3, 8, 7, 5); // Pasa solo 5 argumentos

            // Crear un nuevo personaje usando las instancias de Datos y Caracteristicas
            Personaje personaje = new Personaje(datosPersonaje, caracteristicasPersonaje);

            // Mostrar los datos y características del personaje
            Console.WriteLine($"Nombre del personaje: {personaje.Datos.Nombre}");
            Console.WriteLine($"Tipo de personaje: {personaje.Datos.Tipo}");
            Console.WriteLine($"Edad del personaje: {personaje.Datos.Edad}");
            Console.WriteLine($"Velocidad del personaje: {personaje.Caracteristicas.Velocidad}");
            Console.WriteLine($"Fuerza del personaje: {personaje.Caracteristicas.Fuerza}");
            Console.WriteLine($"Nivel del personaje: {personaje.Caracteristicas.Nivel}");
        }
    }
//==============================================================================================================================//
}
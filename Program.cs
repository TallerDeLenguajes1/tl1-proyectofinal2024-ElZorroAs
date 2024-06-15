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
            for (int i = 1; i < 6; i++)
            {
            // Generar un personaje aleatorio
            Personaje personajeAleatorio = FabricaDePersonajes.CrearPersonajeAleatorio();

            // Mostrar los datos y características del personaje
            Console.WriteLine("[========================================================================]");
            Console.WriteLine($"[                              Personaje {i}                               ]");
            Console.WriteLine("[========================================================================]");
            Console.WriteLine($"Nombre del personaje: {personajeAleatorio.Datos.Nombre}");
            Console.WriteLine($"Tipo de personaje: {personajeAleatorio.Datos.Tipo}");
            Console.WriteLine($"Apodo del personaje: {personajeAleatorio.Datos.Apodo}");
            Console.WriteLine($"Fecha de nacimiento del personaje: {personajeAleatorio.Datos.FechaDeNacimiento.ToShortDateString()}");
            Console.WriteLine($"Edad del personaje: {personajeAleatorio.Datos.Edad}");
            Console.WriteLine($"Velocidad del personaje: {personajeAleatorio.Caracteristicas.Velocidad}");
            Console.WriteLine($"Destreza del personaje: {personajeAleatorio.Caracteristicas.Destreza}");
            Console.WriteLine($"Fuerza del personaje: {personajeAleatorio.Caracteristicas.Fuerza}");
            Console.WriteLine($"Nivel del personaje: {personajeAleatorio.Caracteristicas.Nivel}");
            Console.WriteLine($"Armadura del personaje: {personajeAleatorio.Caracteristicas.Armadura}");
            Console.WriteLine($"Salud del personaje: {personajeAleatorio.Caracteristicas.Salud}");
            Console.WriteLine("[========================================================================]");

            }
        }
    }
//==============================================================================================================================//
}
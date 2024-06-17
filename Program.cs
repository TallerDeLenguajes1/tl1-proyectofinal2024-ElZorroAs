using System;
using System.Threading;

namespace Personajes
{
    //==============================================================================================================================//
    /*
    Prueba de terminal:

    Notas:
    cd C:\Users\fedea\OneDrive\Escritorio\Taller\tl1-proyectofinal2024-ElZorroAs
    dotnet build
    dotnet run
    */
    //==============================================================================================================================//
    class Program
    {
        static void Main(string[] args)
        {
            // Cambiar el tamaño de la consola para demostración
            //Console.SetWindowSize(100, 50);
            Console.WriteLine("\n\n\n\n\n");
            // Mostrar ASCII art de bienvenida
            FuncionesUtiles.MostrarAsciiArtBienvenida(@"
 _                  ____          _          _           
| |       __ _     / ___|  _ __  (_)   ___  | |_    __ _ 
| |      / _` |   | |  _  | '__| | |  / _ \ | __|  / _` |
| |___  | (_| |   | |_| | | |    | | |  __/ | |_  | (_| |
|_____|  \__,_|    \____| |_|    |_|  \___|  \__|  \__,_|
            ");

            FuncionesUtiles.MostrarAsciiArtBienvenida(@"
 ____           _ 
|  _ \    ___  | |
| | | |  / _ \ | |
| |_| | |  __/ | |
|____/   \___| |_|
            ");

            FuncionesUtiles.MostrarAsciiArtBienvenida(@"
 ___                                              _                
|_ _|  _ __   __   __   ___     ___    __ _    __| |   ___    _ __ 
 | |  | '_ \  \ \ / /  / _ \   / __|  / _` |  / _` |  / _ \  | '__|
 | |  | | | |  \ V /  | (_) | | (__  | (_| | | (_| | | (_) | | |   
|___| |_| |_|   \_/    \___/   \___|  \__,_|  \__,_|  \___/  |_|
            ");

            // Texto del menú
            string titulo = "¡La Leyenda del Reino Carmesí!";
            string opcion1 = "1. Empezar nueva partida";
            string opcion2 = "2. Cargar partida guardada";
            string opcion3 = "3. Salir";


            // Centrar el título del menú
            FuncionesUtiles.CentrarTexto(titulo);

            // Espacio en blanco entre el título y las opciones
            Console.WriteLine();

            // Centrar cada opción del menú
            FuncionesUtiles.CentrarTexto(opcion1);
            FuncionesUtiles.CentrarTexto(opcion2);
            FuncionesUtiles.CentrarTexto(opcion3);

            Console.WriteLine("\n\n\n\n");
            // Pausa para ver el mensaje antes de continuar
            Console.WriteLine("\nPresiona Enter para continuar...");
            Console.ReadLine(); // Espera a que el usuario presione Enter

            Console.Clear();

            // Generar y mostrar personajes aleatorios
            for (int i = 1; i < 6; i++)
            {
                Personaje personajeAleatorio = FabricaDePersonajes.CrearPersonajeAleatorio();
                personajeAleatorio.MostrarInformacion(i);

                // Pausa para ver el siguiente personaje
                Console.WriteLine("\nPresiona Enter para ver el siguiente personaje...");
                Console.ReadLine();
                Console.Clear();
            }
        }
    }
    //==============================================================================================================================//
}
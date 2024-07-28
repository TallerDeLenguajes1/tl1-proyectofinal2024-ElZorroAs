using System;
using System.Threading;

namespace EspacioPersonaje
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

             string nombreArchivo = "personajes.json";
            List<Personaje> personajes;

            if (PersonajeJson.Existe(nombreArchivo))
            {
                personajes = PersonajeJson.LeerPersonajes(nombreArchivo);
                Console.WriteLine("Personajes cargados desde el archivo existente:");
            }
            else
            {
                personajes = new List<Personaje>();
                FabricaDePersonajes fabrica = new FabricaDePersonajes();
                for (int i = 0; i < 10; i++)
                {
                    personajes.Add(FabricaDePersonajes.CrearPersonajeAleatorio());
                }

                PersonajeJson.GuardarPersonajes(personajes, nombreArchivo);
                Console.WriteLine("Se generaron 10 nuevos personajes y se guardaron en el archivo.");
            }
            int contador=1;
             foreach (var personaje in personajes)
            {
                personaje.MostrarInformacion(contador);
                contador++;
            }

            /*
            Console.WriteLine("\n\n\n\n\n");
            // Mostrar ASCII art de bienvenida
            FuncionesUtiles.MostrarAsciiArtBienvenida(1);

            FuncionesUtiles.MostrarAsciiArtBienvenida(2);

            FuncionesUtiles.MostrarAsciiArtBienvenida(3);

            // Centrar el título del menú
            FuncionesUtiles.CentrarTexto("La Leyenda del Reino Carmesí!");

            // Espacio en blanco entre el título y las opciones
            Console.WriteLine();

            // Centrar cada opción del menú
            FuncionesUtiles.CentrarTexto("1. Empezar nueva partida");
            FuncionesUtiles.CentrarTexto("2. Elegir personajes");
            FuncionesUtiles.CentrarTexto("3. Salir");

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
            */
        }
    }
    //==============================================================================================================================//
}
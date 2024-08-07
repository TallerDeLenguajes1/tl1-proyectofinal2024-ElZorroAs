﻿using System;
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
        static async Task Main(string[] args)
        {
            /*
            1) Verificar al comienzo del Juego si existe el archivo de personajes:
                A. Si existe y tiene datos cargar los personajes desde el archivo existente.
                B. Si no existe generar 10 personajes utilizando la clase FabricaDePersonajes y
                guárdelos en el archivo de personajes usando la clase PersonajesJson.
            2) Muestre por pantalla los datos y características de los personajes cargados. 
            */
            Personaje usuario=null;
            Personaje rival=null;


            string nombreArchivo = "personajes.json";
            List<Personaje> personajes;
            FabricaDePersonajes fabrica = new FabricaDePersonajes();

            if (PersonajeJson.Existe(nombreArchivo))
            {
                personajes = PersonajeJson.LeerPersonajes(nombreArchivo);
                Console.WriteLine("Personajes cargados desde el archivo existente:");
            }
            else
            {
                // Si el archivo no existe, solicita nuevos personajes de la API y guarda en el archivo
                personajes = await fabrica.ConectarApi();
                PersonajeJson.GuardarPersonajes(personajes, nombreArchivo);
                Console.WriteLine(
                    "Se generaron nuevos personajes y se guardaron en el archivo."
                );
            }

            /*
            int contador=1;
            foreach (var personaje in personajes)
            {
               personaje.MostrarInformacion(contador);
               contador++;
            }
            */

            int opcion;
            do
            {
                Console.WriteLine("\n\n\n\n\n");
                // Mostrar ASCII art de bienvenida
                FuncionesUtiles.MostrarAsciiArtBienvenida(1);

                FuncionesUtiles.MostrarAsciiArtBienvenida(2);

                FuncionesUtiles.MostrarAsciiArtBienvenida(3);

                Console.ForegroundColor = ConsoleColor.Red;
                // Centrar el título del menú
                FuncionesUtiles.CentrarTexto("La Leyenda del Reino Carmesí!");
                Console.ResetColor();
                // Espacio en blanco entre el título y las opciones
                Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.Yellow;
                // Centrar cada opción del menú
                FuncionesUtiles.CentrarTexto("1. Empezar nueva partida");
                FuncionesUtiles.CentrarTexto("2. Mostrar ganadores");
                FuncionesUtiles.CentrarTexto("3. Salir");
                Console.ResetColor();

                Console.WriteLine("\n\n\n\n");
                // Pausa para ver el mensaje antes de continuar


                if (int.TryParse(Console.ReadLine(), out opcion))
                {
                    switch (opcion)
                    {
                        case 1:

                            if (personajes.Count < 4)
                            {
                                personajes = await fabrica.ConectarApi();
                                PersonajeJson.GuardarPersonajes(personajes, nombreArchivo);
                            }

                            usuario = Eleccion.ElegirPersonajeUsuario(personajes);
                            rival = Eleccion.ElegirRival(personajes);

                            // Muestra los personajes seleccionados y realiza la batalla

                            Console.ForegroundColor = ConsoleColor.Blue;
                            FuncionesUtiles.CentrarTexto("Tu personaje:");
                            usuario.MostrarInformacion();
                            Console.ResetColor();

                            Console.ForegroundColor = ConsoleColor.Red;
                            FuncionesUtiles.CentrarTexto("Personaje del rival:");
                            rival.MostrarInformacion();
                            Console.ResetColor();

                            Combate combate = new Combate(usuario, rival);

                            combate.Batalla(personajes);
                            break;
                        case 2:
                            // Opción 3: Mostrar el historial de ganadores
                            HistorialJson historialJson = new HistorialJson();
                            List<Ganador> ganadores =
                                historialJson.LeerGanadores("ganadores.json")
                                ?? new List<Ganador>();

                            if (ganadores != null && ganadores.Count > 0)
                            {
                                FuncionesUtiles.CentrarTexto(
                                    "Historial de ganadores:\n"
                                );
                                for (int i = 0; i < ganadores.Count; i++)
                                {
                                    var ganador = ganadores[i];
                                    string textoGanador = $"{i + 1}. Nombre: {ganador.personajeGanador.Datos.Nombre}, Tipo: {ganador.personajeGanador.Datos.Tipo}, Fecha: {ganador.fechaVictoria}";
                                    FuncionesUtiles.CentrarTexto(
                                        textoGanador
                                    );
                                }
                            }
                            else
                            {
                                Console.WriteLine("No hay ganadores registrados.");
                            }
                            break;
                        case 3:
                            Console.WriteLine("Saliendo del programa...");
                            break;
                        default:
                            Console.WriteLine("Opción no válida. Intenta de nuevo.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Entrada no válida. Intenta de nuevo.");
                }

                if (opcion != 3)
                {
                    Console.WriteLine("Presiona cualquier tecla para continuar...");
                    Console.ReadKey();
                }

            } while (opcion != 3);
        }
    }
}
//==============================================================================================================================//
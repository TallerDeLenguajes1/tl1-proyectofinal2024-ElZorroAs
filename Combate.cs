using System;
using System.Collections.Generic;

namespace EspacioPersonaje
{
    //==============================================================================================================================//
    /*
    Mecánica del Juego
        2) El combate se realiza por turnos. Por cada turno un personaje ataca y el otro se
        defiende.
        3) El combate se mantiene hasta que uno es vencido (salud <= 0)
        4) El personaje que pierde la batalla es eliminado de la competencia
    */
    //==============================================================================================================================//
    public class Combate
    {
        private Personaje personajeUsuario; // Personaje controlado por el usuario
        private Personaje personajeRival; // Personaje rival aleatorio
        private HistorialJson historialJson; // Instancia para manejar el historial en formato JSON

        // Constructor que inicializa los personajes y las instancias de Mensajes e HistorialJson
        public Combate(Personaje personajeUsuario, Personaje personajeRival)
        {
            this.personajeUsuario = personajeUsuario; // Almacena el personaje del usuario
            this.personajeRival = personajeRival;
            this.historialJson = new HistorialJson(); // Se crea y se almacena una nueva para manejar el historial del combate en formato JSON
        }

        // Método principal de la batalla
        public void Batalla(List<Personaje> personajes)
        {
            //evalúa si ambos personajes siguen vivos
            while (personajeUsuario.Caracteristicas.Salud > 0 && personajeRival.Caracteristicas.Salud > 0)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                // Turno del usuario
                FuncionesUtiles.CentrarTexto("[=======================================================]");
                FuncionesUtiles.CentrarTexto("Turno del usuario:");
                TurnoUsuario(); // invoco al metodo del usuario

                //verifica si el rival fue vencido
                if (personajeRival.Caracteristicas.Salud <= 0)
                {
                    // El usuario derrotó al rival
                    FuncionesUtiles.CentrarTexto("El enemigo fue vencido!!!");
                    if (personajes.Count > 0)
                    {
                        FuncionesUtiles.CentrarTexto(
                            $"¡Has derrotado a {personajeRival.Datos.Nombre}!"
                        );
                        // conteo de rivales restantes al mostrar el mensaje
                        FuncionesUtiles.CentrarTexto(
                            $"Te quedan {personajes.Count} rivales para la victoria."
                        );
                    }
                    Beneficiar(personajeUsuario); // Beneficia al personaje del usuario
                    Console.ResetColor();
                    break;
                }


                Console.ForegroundColor = ConsoleColor.Red;
                // Turno del rival
                FuncionesUtiles.CentrarTexto("[=======================================================]");
                FuncionesUtiles.CentrarTexto("Turno del rival:");
                TurnoRival();

                if (personajeUsuario.Caracteristicas.Salud <= 0)
                {
                    // El rival derrotó al usuario
                    FuncionesUtiles.CentrarTexto("Tu personaje fue vencido");
                    break;
                }
            }

            // Verifica si el usuario ganó la batalla actual y si quedan rivales
            if (personajeUsuario.Caracteristicas.Salud > 0 && personajes.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                // El usuario ha ganado contra todos los rivales
                FuncionesUtiles.CentrarTexto("\n");
                FuncionesUtiles.CentrarTexto("[MMM]");
                FuncionesUtiles.CentrarTexto("[MMMMMMMMMMMMMMMMM]");
                FuncionesUtiles.CentrarTexto("[MMMMMMMMMMMMMMMMMMMMMMMMMMM]");
                FuncionesUtiles.CentrarTexto("[MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM]");
                FuncionesUtiles.CentrarTexto("[MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM]");
                FuncionesUtiles.CentrarTexto("[MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM]");
                FuncionesUtiles.CentrarTexto("[MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM]");
                FuncionesUtiles.CentrarTexto("[MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM]");
                FuncionesUtiles.CentrarTexto("[MM                                                                   MM]");
                FuncionesUtiles.CentrarTexto("[MM              !!!Campeon de La Grieta Del Invocador!!!             MM]");
                FuncionesUtiles.CentrarTexto("[MM                                                                   MM]");
                FuncionesUtiles.CentrarTexto("[MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM]");
                FuncionesUtiles.CentrarTexto("     MMM     MMM     MMM     MMM     MMM     MMM     MMM     MMM     MMM     ");
                FuncionesUtiles.CentrarTexto("     MMM     MMM     MMM     MMM     MMM     MMM     MMM     MMM     MMM     ");
                FuncionesUtiles.CentrarTexto("     MMM     MMM     MMM     MMM     MMM     MMM     MMM     MMM     MMM     ");
                FuncionesUtiles.CentrarTexto("     MMM     MMM     MMM     MMM     MMM     MMM     MMM     MMM     MMM     ");
                FuncionesUtiles.CentrarTexto("     MMM     MMM     MMM     MMM     MMM     MMM     MMM     MMM     MMM     ");
                FuncionesUtiles.CentrarTexto("     MMM     MMM     MMM     MMM     MMM     MMM     MMM     MMM     MMM     ");
                FuncionesUtiles.CentrarTexto("     MMM     MMM     MMM     MMM     MMM     MMM     MMM     MMM     MMM     ");
                FuncionesUtiles.CentrarTexto("     MMM     MMM     MMM     MMM     MMM     MMM     MMM     MMM     MMM     ");
                FuncionesUtiles.CentrarTexto("     MMM     MMM     MMM     MMM     MMM     MMM     MMM     MMM     MMM     ");
                FuncionesUtiles.CentrarTexto("     MMM     MMM     MMM     MMM     MMM     MMM     MMM     MMM     MMM     ");
                FuncionesUtiles.CentrarTexto("[MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM]");
                FuncionesUtiles.CentrarTexto("[MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM]");
                FuncionesUtiles.CentrarTexto("[MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM]");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Red;
                historialJson.GuardarGanador(personajeUsuario, DateTime.Now, "ganadores.json");
                Console.ResetColor();
            }
            // verifica si tiene salud para seguir peleando
            else if (personajeUsuario.Caracteristicas.Salud > 0)
            {
                MenuBatalla(personajes); // Muestra el menú de batalla para continuar
            }
            Console.ResetColor();
        }


        // Método para mostrar el menú de batalla y permitir al usuario continuar, guardar o salir
        private void MenuBatalla(List<Personaje> personajes)
        {
            // verifica si el personaje aun esta vivo 
            if (!(personajeUsuario.Caracteristicas.Salud <= 0))
            {
                bool continuar = true;
                while (continuar)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    FuncionesUtiles.CentrarTexto("\n");
                    FuncionesUtiles.CentrarTexto("¿Desea continuar el juego?");
                    FuncionesUtiles.CentrarTexto("1. Continuar");
                    FuncionesUtiles.CentrarTexto("2. Salir");
                    string opcion = Console.ReadLine();
                    Console.ResetColor();

                    switch (opcion)
                    {
                        case "1":
                            personajeRival = Eleccion.ElegirRival(personajes); // Elegir el siguiente rival
                            Batalla(personajes); // llamo al metodo batalla
                            continuar = false;
                            return;

                        case "2":
                            Console.WriteLine(
                                "\nTu Personaje no continuo con la batalla.\n"
                            );
                            continuar = false;
                            return;
                        default:
                            Console.WriteLine("\nOpción no válida. Intenta nuevamente.\n");
                            break;
                    }
                }
            }
        }

        // Método para manejar el turno del usuario
        private void TurnoUsuario()
        {
            FuncionesUtiles.CentrarTexto("!!!Elige tu habilidad!!!");
            for (int i = 0; i < personajeUsuario.Datos.Habilidades.Count; i++)
            {
                // Itera sobre cada habilidad en la lista de habilidades del personaje
                var habilidades = personajeUsuario.Datos.Habilidades[i];
                FuncionesUtiles.CentrarTexto($"{i + 1}. {habilidades.Nombre} (Ataque: {habilidades.Ataque})");
            }

            int seleccion = 0;

            while (seleccion < 1 || seleccion > personajeUsuario.Datos.Habilidades.Count)
            {
                FuncionesUtiles.CentrarTexto("[========= Selecciona el número de la habilidad =========]");
                if (int.TryParse(Console.ReadLine(), out seleccion) && seleccion >= 1 && seleccion <= personajeUsuario.Datos.Habilidades.Count)
                {
                    Habilidades habilidadSeleccionada = personajeUsuario.Datos.Habilidades[seleccion - 1];
                    FuncionesUtiles.CentrarTexto($"Has elegido usar la habilidad: {habilidadSeleccionada.Nombre}");

                    int danio = personajeUsuario.Caracteristicas.Calculardanio(habilidadSeleccionada);

                    personajeRival.Caracteristicas.ActualizarSalud(danio);

                    FuncionesUtiles.CentrarTexto($"La salud del personaje rival ahora es: {personajeRival.Caracteristicas.Salud}");
                    FuncionesUtiles.CentrarTexto($"[=======================================================]");
                    FuncionesUtiles.CentrarTexto($"\n");

                    break;
                }
                else
                {
                    FuncionesUtiles.CentrarTexto("Selección no válida. Intenta de nuevo.");
                }
            }
        }

        // Método para manejar el turno del rival
        private void TurnoRival()
        {
            // Crea una instancia de la clase Random para generar números aleatorios
            Random random = new Random();
            int seleccion = random.Next(personajeRival.Datos.Habilidades.Count);// Selecciona una habilidad aleatoria

            // Obtiene la habilidad seleccionada del rival usando el índice aleatorio generado
            Habilidades habilidadSeleccionada = personajeRival.Datos.Habilidades[seleccion];

            FuncionesUtiles.CentrarTexto($"El rival usa la habilidad: {habilidadSeleccionada.Nombre}");

            int danio = personajeRival.Caracteristicas.Calculardanio(habilidadSeleccionada);
            personajeUsuario.Caracteristicas.ActualizarSalud(danio);

            FuncionesUtiles.CentrarTexto($"El daño infligido es: {danio}");
            FuncionesUtiles.CentrarTexto($"La salud del personaje usuario ahora es: {personajeUsuario.Caracteristicas.Salud}");
            FuncionesUtiles.CentrarTexto($"[=======================================================]");
            FuncionesUtiles.CentrarTexto($"\n");
        }

        /*
        5) El que gane es beneficiado con una mejora en sus habilidades.
        por ejemplo: +10 en salud o +5 en defensa. 
        */

        // Método para beneficiar al Personaje del usuario después de ganar un combate
        private void Beneficiar(Personaje ganador)
        {
            ganador.Caracteristicas.ModificarSalud();
            ganador.Caracteristicas.AumentarEstadisticaAleatoria();
            FuncionesUtiles.CentrarTexto("¡Tu Personaje ha ganado el combate y ha obtenido mejoras!\n");
            FuncionesUtiles.CentrarTexto("Mejoras del Personaje: ");
            ganador.Caracteristicas.MostrarEstadisticas();
        }
    }
    //==============================================================================================================================//
}
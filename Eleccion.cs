//==============================================================================================================================//
/*
Mecánica del Juego 
                1) Elija 2 personajes para que compitan entre ellos. 
*/
//==============================================================================================================================//
using System;
using System.Collections.Generic;

namespace EspacioPersonaje
{
    public class Eleccion
    {
        public (Personaje, Personaje) ElegirPersonajes(List<Personaje> personajes)
        {
            if (personajes.Count < 1)
            {
                throw new ArgumentException("No hay suficientes personajes para elegir.");
            }

            FuncionesUtiles.CentrarTexto("Es tu turno de elegir tu Personaje. Presiona cualquier tecla para continuar.");
            Console.ReadKey(); // Espera a que el usuario presione una tecla para continuar.
            Personaje personajeUsuario = SeleccionarPersonaje(personajes, "usuario"); // Permite al usuario seleccionar su personaje.
            personajes.Remove(personajeUsuario); // Elimina el personaje seleccionado del listado de personajes disponibles.

            FuncionesUtiles.CentrarTexto("Tu rival es:");
            Personaje personajeRival = ElegirNuevoRival(personajes); // Selecciona un nuevo rival aleatorio.
            return (personajeUsuario, personajeRival); // Retorna una tupla con el personaje del usuario y el rival.
        }

        public Personaje ElegirNuevoRival(List<Personaje> personajes)
        {
            if (personajes.Count < 1)
            {
                throw new ArgumentException("No hay suficientes personajes para elegir un nuevo rival.");
            }
            Random random = new Random(); // Instancia de la clase Random para generar un número aleatorio.
            int indiceAleatorio = random.Next(personajes.Count); // Genera un índice aleatorio en el rango de la lista.
            Personaje personajeRival = personajes[indiceAleatorio]; // Selecciona el personaje en el índice aleatorio.
            personajes.Remove(personajeRival); // Elimina el personaje seleccionado de la lista.
            Console.Clear(); // Limpia la consola.
            personajeRival.MostrarInformacion(); // Muestra los detalles del personaje rival.
            return personajeRival; // Retorna el personaje rival seleccionado.
        }

        private Personaje SeleccionarPersonaje(List<Personaje> personajes, string tipoSeleccion)
        {
            int indicePersonaje = 0; // Índice del Personaje actualmente seleccionado.
            ConsoleKeyInfo tecla; // Variable para almacenar la tecla presionada por el usuario.
            Personaje PersonajeElegido = personajes[indicePersonaje]; // Inicializa el Personaje elegido con el primero de la lista.
            int cantidadMaximaPersonajes = 4; // Máximo número de personajes a mostrar
            int contadorPersonajesMostrados = 0; // Contador para rastrear la cantidad de personajes mostrados

            do
            {
                Console.Clear(); // Limpia la consola.
                personajes[indicePersonaje].MostrarInformacionContador(contadorPersonajesMostrados + 1); // Muestra los detalles del Personaje actual.
                FuncionesUtiles.CentrarTexto("Presiona [Enter] para ver el siguiente Personaje.");
                FuncionesUtiles.CentrarTexto("Presiona [Espacio] para seleccionar el Personaje actual.");

                tecla = Console.ReadKey(); // Lee la tecla presionada por el usuario.

                if (tecla.Key == ConsoleKey.Enter)
                {
                    // Navega al siguiente Personaje en la lista.
                    indicePersonaje = (indicePersonaje + 1) % personajes.Count; // Usa el operador módulo para circular al principio de la lista.
                    contadorPersonajesMostrados++; // Incrementa el contador de personajes mostrados

                    if (contadorPersonajesMostrados >= cantidadMaximaPersonajes)
                    {
                        // Si se ha alcanzado el número máximo de personajes mostrados, reiniciar el contador
                        contadorPersonajesMostrados = 0;
                    }
                }
                else if (tecla.Key == ConsoleKey.Spacebar)
                {
                    // Selecciona el Personaje actual y sale del bucle.
                    PersonajeElegido = personajes[indicePersonaje];
                    FuncionesUtiles.CentrarTexto($"Has elegido a: {PersonajeElegido.Datos.Nombre}!");
                    break;
                }

            } while (true); // Bucle infinito hasta que el usuario haga una selección.

            FuncionesUtiles.CentrarTexto($"Has confirmado tu elección: {PersonajeElegido.Datos.Nombre}");
            return PersonajeElegido; // Retorna el Personaje elegido.
        }
    }
}
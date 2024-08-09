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
    public static class Eleccion
    {
        public static Personaje ElegirPersonajeUsuario(List<Personaje> personajes)
        {
            if (personajes.Count < 1)
            {
                throw new ArgumentException("No hay suficientes personajes para elegir.");
            }

            int indicePersonaje = 0;
            ConsoleKeyInfo tecla; // Lee la tecla presionada y almacena la información en la variable 'tecla'
            Personaje personajeUsuario = personajes[indicePersonaje];
            int cantidadMaximaPersonajes = 4;
            int contadorPersonajesMostrados = 0;

            do
            {
                Console.Clear();
                personajeUsuario.MostrarInformacionContador(contadorPersonajesMostrados + 1);

                FuncionesUtiles.CentrarTexto("Presiona [Enter] para ver el siguiente Personaje.");
                FuncionesUtiles.CentrarTexto(
                    "Presiona [Espacio] para seleccionar el Personaje actual."
                );

                tecla = Console.ReadKey();

                if (tecla.Key == ConsoleKey.Enter)
                {
                    // Avanzar al siguiente personaje en la lista
                    indicePersonaje = (indicePersonaje + 1) % personajes.Count;
                    contadorPersonajesMostrados++;

                    // Verifica si el contador ha alcanzado la cantidad máxima
                    if (contadorPersonajesMostrados >= cantidadMaximaPersonajes)
                    {
                        contadorPersonajesMostrados = 0;
                    }

                    // Actualiza el personaje mostrado
                    personajeUsuario = personajes[indicePersonaje];
                }
                else if (tecla.Key == ConsoleKey.Spacebar)
                {
                    // El usuario ha seleccionado el personaje
                    FuncionesUtiles.CentrarTexto(
                        $"Has elegido a: {personajeUsuario.Datos.Nombre}!"
                    );
                    break;
                }
            } while (true);

            FuncionesUtiles.CentrarTexto(
                $"Has confirmado tu elección: {personajeUsuario.Datos.Nombre}"
            );

            // Elimina el personaje seleccionado de la lista
            personajes.Remove(personajeUsuario);

            return personajeUsuario;
        }

        public static Personaje ElegirRival(List<Personaje> personajes)
        {
            if (personajes.Count < 1)
            {
                throw new ArgumentException(
                    "No hay suficientes personajes para elegir un nuevo rival."
                );
            }

            Random random = new Random();
            int indiceAleatorio = random.Next(personajes.Count);
            Personaje personajeRival = personajes[indiceAleatorio];
            personajes.Remove(personajeRival);
            Console.Clear();
            personajeRival.MostrarInformacion();
            return personajeRival;
        }
    }
}
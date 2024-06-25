using System;

namespace Personajes
{
//==============================================================================================================================//
/*
2da parte Generación de valores aleatorios:
*/
//==============================================================================================================================//
    public class FabricaDePersonajes
    {
        private static readonly string[] tipos = { "Humano", "Elfo", "Enano", "Orco" };
        private static readonly string[] nombres = { "John", "Aragorn", "Gimli", "Legolas", "Frodo", "Sam" };
        private static readonly string[] apodos = { "El Valiente", "El Fuerte", "El Ágil", "El Sabio", "El Oscuro", "El Justo" };

        private static readonly Random random = new Random();

        public static Personaje CrearPersonajeAleatorio()
        {
            // Generar datos aleatorios
            string tipo = tipos[random.Next(tipos.Length)];
            string nombre = nombres[random.Next(nombres.Length)];
            string apodo = apodos[random.Next(apodos.Length)];
            DateTime fechaDeNacimiento = GenerarFechaAleatoria();
            int edad = CalcularEdad(fechaDeNacimiento);

            Datos datos = new Datos(tipo, nombre, apodo, fechaDeNacimiento, edad);

            // Generar características aleatorias
            int velocidad = random.Next(1, 11);
            int destreza = random.Next(1, 6);
            int fuerza = random.Next(1, 11);
            int nivel = random.Next(1, 11);
            int armadura = random.Next(1, 11);

            Caracteristicas caracteristicas = new Caracteristicas(velocidad, destreza, fuerza, nivel, armadura);

            // Crear y devolver el personaje
            return new Personaje(datos, caracteristicas);
        }

        private static DateTime GenerarFechaAleatoria()
        {
            int year = random.Next(DateTime.Now.Year - 300, DateTime.Now.Year);
            int month = random.Next(1, 13);
            int day = random.Next(1, DateTime.DaysInMonth(year, month) + 1);

            return new DateTime(year, month, day);
        }

        private static int CalcularEdad(DateTime fechaDeNacimiento)
    {
        DateTime fechaActual = DateTime.Now;
        int edad = fechaActual.Year - fechaDeNacimiento.Year;

        if (fechaActual.Month < fechaDeNacimiento.Month || (fechaActual.Month == fechaDeNacimiento.Month && fechaActual.Day < fechaDeNacimiento.Day))
        {
            edad--;
        }

        return edad;
    }
    }
//==============================================================================================================================//
}

using System;

namespace EspacioPersonaje
{
    //==============================================================================================================================//
    /*
    2da parte Generación de valores aleatorios:
    */
    //==============================================================================================================================//
    public class FabricaDePersonajes
    {
        //==============================================================================================================================//
        // Diccionario de habilidades
        private static Random random = new Random();

        private static string[] tipos = { "Guerrero", "Mago" };
        private static string[] apodos = { "El Conquistador", "El Destructor", "El Hechicero", "La Ilusionista" };

        //==============================================================================================================================//
        //Diccionario 
        private static Dictionary<string, List<string>> habilidades = new Dictionary<string, List<string>>()
        {
            { "Pantheon", new List<string> { "Cometa", "Escudo del Alba", "Lanza Suprema", "Asalto Aegis" } },
            { "Aatrox", new List<string> { "La Espada Darkin", "Cadenas Infernales", "Desata su Poder", "Luz Umbría" } },
            { "Swain", new List<string> { "Mano de la Muerte", "Visión Imperial", "Mutilador", "Nunca Más" } },
            { "Leblanc", new List<string> { "Sigilo de la Malevolencia", "Distorsión", "Cadenas Etéreas", "Mimética" } }
        };
        //==============================================================================================================================//
        public static Personaje CrearPersonajeAleatorio()
        {
            string tipo = tipos[random.Next(tipos.Length)];
            string nombre = ElegirNombreAleatorio();
            string apodo = apodos[random.Next(apodos.Length)];
            DateTime fechaDeNacimiento = GenerarFechaAleatoria();
            int edad = CalcularEdad(fechaDeNacimiento);

            // Generar habilidades aleatorias
            List<Habilidades> habilidadesPersonaje = new List<Habilidades>(); // Crear una lista para almacenar las habilidades del personaje

            // Verificar si el diccionario de habilidades contiene el nombre del personaje
            if (habilidades.ContainsKey(nombre))
            {
                // Iterar sobre cada habilidad asociada al nombre del personaje en el diccionario
                foreach (var habilidad in habilidades[nombre])
                {
                    // Crear una nueva instancia de Habilidades con la habilidad y un valor aleatorio de 1 a 10
                    habilidadesPersonaje.Add(new Habilidades(habilidad, random.Next(1, 11)));
                }
            }
            // Crear una instancia de Datos con el tipo, nombre, apodo, fecha de nacimiento, edad y la lista de habilidades generadas
            Datos datos = new Datos(tipo, nombre, apodo, fechaDeNacimiento, edad, habilidadesPersonaje);

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

        private static string ElegirNombreAleatorio()
        {
            List<string> nombres = new List<string>(habilidades.Keys);
            return nombres[random.Next(nombres.Count)];
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
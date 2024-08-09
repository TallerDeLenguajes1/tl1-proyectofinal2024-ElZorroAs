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
        private static Random random = new Random();// Instancia de la clase Random para generar valores aleatorios
        // Diccionario que mapea nombres de campeones a su tipo (ej. Mage, Marksman)
        private static Dictionary<string, string> tiposCampeones = new Dictionary<string, string>()
        {
            { "Orianna", "Mage" }, // Mage
            { "Ashe", "Marksman" }, // Marksman
            { "Ryze", "Mage" }, // Mage
            { "Lux", "Mage" }, // Mage
            { "Ezreal", "Marksman" }, // Marksman
            { "Katarina", "Assassin" }, // Assassin
            { "Pantheon", "Fighter" }, // Fighter
            { "Aatrox", "Fighter" }, // Fighter
            { "Swain", "Mage" }, // Mage
            { "Leblanc", "Mage" } // Mage
        };
        // Diccionario que mapea nombres de campeones a sus apodos
        private static Dictionary<string, string> apodosCampeones = new Dictionary<string, string>()
        {
            { "Orianna", "La Doncella Mecánica" },
            { "Ashe", "La Arquera de Hielo" },
            { "Ryze", "El Hechicero Rúnico" },
            { "Lux", "La Dama Luminosa" },
            { "Ezreal", "El Explorador Pródigo" },
            { "Katarina", "La Sinfonía Roja" },
            { "Pantheon", "El Artesano de Guerra" },
            { "Aatrox", "La Espada Darkin" },
            { "Swain", "El Gran General" },
            { "Leblanc", "La Maquiavélica" }
        };
        // Diccionario que mapea nombres de campeones a una lista de sus habilidades
        private static Dictionary<string, List<string>> habilidades = new Dictionary<
            string,
            List<string>
        >()
        {
            {
                "Orianna",
                new List<string>
                {
                    "Ataque de Comando",
                    "Protección de Comando",
                    "Onda de Choque",
                    "Comando: Shockwave"
                }
            },
            {
                "Ashe",
                new List<string>
                {
                    "Foco de Cazadora",
                    "Descarga de Flechas",
                    "Visión de Águila",
                    "Flecha de Cristal"
                }
            },
            {
                "Ryze",
                new List<string>
                {
                    "Carga de Mana",
                    "Flujo de Energía",
                    "Ruptura de Portal",
                    "Tormenta de Mana"
                }
            },
            {
                "Lux",
                new List<string>
                {
                    "Luz Prisma",
                    "Barrera de Luz",
                    "Singulidad Luminosa",
                    "Destello Final"
                }
            },
            {
                "Ezreal",
                new List<string>
                {
                    "Tiro Místico",
                    "Flujo de Energía",
                    "Desplazamiento Arcano",
                    "Barrage de Proyectiles"
                }
            },
            {
                "Katarina",
                new List<string>
                {
                    "Voracidad",
                    "Flujo de Sangre",
                    "Grito de Guerra",
                    "Loto de Muerte"
                }
            },
            {
                "Pantheon",
                new List<string> { "Cometa", "Escudo del Alba", "Lanza Suprema", "Asalto Aegis" }
            },
            {
                "Aatrox",
                new List<string>
                {
                    "La Espada Darkin",
                    "Cadenas Infernales",
                    "Desata su Poder",
                    "Luz Umbría"
                }
            },
            {
                "Swain",
                new List<string>
                {
                    "Mano de la Muerte",
                    "Visión Imperial",
                    "Mutilador",
                    "Nunca Más"
                }
            },
            {
                "Leblanc",
                new List<string>
                {
                    "Sigilo de la Malevolencia",
                    "Distorsión",
                    "Cadenas Etéreas",
                    "Mimética"
                }
            }
        };
        // Método para crear un personaje con datos opcionales de la API
        public Task<Personaje> CrearPersonaje(bool usarApi)
        {
            string nombre = null;
            string tipo = "Desconocido";
            string apodo = null;
            DateTime fechaDeNacimiento = GenerarFechaAleatoria();
            int edad = CalcularEdad(fechaDeNacimiento);
            // Determina los detalles del personaje dependiendo de si se usa la API o no
            if (usarApi)
            {
                nombre = tiposCampeones.Keys.ElementAt(random.Next(tiposCampeones.Count));
                tipo = tiposCampeones[nombre];
                apodo = apodosCampeones[nombre];
            }
            else
            {
                nombre = ElegirNombreAleatorio();
                tipo = tiposCampeones.ContainsKey(nombre) ? tiposCampeones[nombre] : "Desconocido";
                apodo = apodosCampeones.ContainsKey(nombre)
                    ? apodosCampeones[nombre]
                    : "Apodo desconocido";
            }

            // Verificar que el tipo del personaje sea válido usando el diccionario de campeones
            if (!tiposCampeones.Values.Contains(tipo))
            {
                throw new ArgumentException($"Tipo de personaje no válido: {tipo}");
            }

            // Obtener habilidades del diccionario
            List<Habilidades> habilidadesPersonaje = new List<Habilidades>();
            if (habilidades.ContainsKey(nombre))
            {
                foreach (var habilidad in habilidades[nombre])
                {
                    habilidadesPersonaje.Add(new Habilidades(habilidad, random.Next(1, 11)));
                }
            }
            else
            {
                // Si el nombre no tiene habilidades en el diccionario, asigna habilidades genéricas
                habilidadesPersonaje.Add(new Habilidades("Habilidad1", random.Next(1, 11)));
                habilidadesPersonaje.Add(new Habilidades("Habilidad2", random.Next(1, 11)));
            }
            //==============================================================================================================================//

            // Generar características aleatorias
            int velocidad = random.Next(1, 11);
            int destreza = random.Next(1, 6);
            int fuerza = random.Next(1, 11);
            int nivel = random.Next(1, 11);
            int armadura = random.Next(1, 11);

            Caracteristicas caracteristicas = new Caracteristicas(
                velocidad,
                destreza,
                fuerza,
                nivel,
                armadura
            );

            Datos datos = new Datos(
                tipo,
                nombre,
                apodo,
                fechaDeNacimiento,
                edad,
                habilidadesPersonaje
            );

            return Task.FromResult(new Personaje(datos, caracteristicas));
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

            if (
                fechaActual.Month < fechaDeNacimiento.Month
                || (
                    fechaActual.Month == fechaDeNacimiento.Month
                    && fechaActual.Day < fechaDeNacimiento.Day
                )
            )
            {
                edad--;
            }

            return edad;
        }

        public async Task<List<Personaje>> ConectarApi()
        {
            FuncionesUtiles.CentrarTexto("¿Deseas usar la API para crear personajes? (S/N): ");
            Console.WriteLine();

            bool usarApi = Console.ReadLine().Trim().ToUpper() == "S";
            List<Personaje> personajes = new List<Personaje>();

            if (usarApi)
            {
                try
                {
                    // Intentar crear 4 personajes usando la API
                    for (int i = 0; i < 4; i++)
                    {
                        personajes.Add(await CrearPersonaje(usarApi));
                    }
                }
                catch (HttpRequestException)
                {
                    // Si falla, notificar al usuario y usar datos precargados
                    FuncionesUtiles.CentrarTexto("No se pudo conectar a la API. Generando personajes con datos precargados...");
                    usarApi = false;
                }
            }

            if (!usarApi)
            {
                // Crear 4 personajes usando datos precargados
                for (int i = 0; i < 4; i++)
                {
                    personajes.Add(await CrearPersonaje(false));
                }
            }

            return personajes;
        }

    }
    //==============================================================================================================================//
}
using System;

namespace EspacioPersonaje
{
    //==============================================================================================================================//
    /*
    1ra parte Generación de personaje:
    Datos:
        velocidad;  // 1 a 10
        destreza;   //1 a 5
        fuerza;     //1 a 10
        Nivel;      //1 a 10
        Armadura;   //1 a 10
        Salud:      //100
    */
    //==============================================================================================================================//
    public class Caracteristicas
    {
        private int velocidad; // 1 a 10
        private int destreza; // 1 a 5
        private int fuerza; // 1 a 10
        private int nivel; // 1 a 10
        private int armadura; // 1 a 10
        private int salud; // 100
        private const int ConstanteAjuste = 500; // Constante de ajuste
        // Constructor actualizado para incluir el parámetro nivel
        public Caracteristicas(int velocidad, int destreza, int fuerza, int nivel, int armadura)
        {
            this.Velocidad = velocidad;
            this.Destreza = destreza;
            this.Fuerza = fuerza;
            this.Nivel = nivel;
            this.Armadura = armadura;
            this.salud = 100; // Salud inicial siempre es 100

        }

        public int Velocidad
        {
            // El getter devuelve el valor de la variable
            get => velocidad;

            // El setter privado asigna un valor a la variable privada. 
            // Al ser privado, solo se puede modificar desde dentro de la misma clase.
            private set => velocidad = value;
        }

        public int Destreza
        {
            get => destreza;
            private set => destreza = value;
        }

        public int Fuerza
        {
            get => fuerza;
            private set => fuerza = value;
        }

        public int Nivel
        {
            get => nivel;
            private set => nivel = value;
        }

        public int Armadura
        {
            get => armadura;
            private set => armadura = value;
        }

        public int Salud
        {
            get => salud;
            private set => salud = value;
        }
    //==============================================================================================================================//

    //==============================================================================================================================//
    /*
    Mecánica del Combate:
                        La forma de calcular el daño provocado en cada turno es la siguiente:
    */
    //==============================================================================================================================//
        
        // Método para calcular el ataque basado en las características del personaje
        //• Ataque: Destreza * Fuerza * Nivel (del personaje que ataca)
        public double CalcularAtaque(Habilidades habilidades)
        {
            return Destreza * Fuerza * Nivel * habilidades.Ataque;
        }

        // Efectividad: Valor aleatorio entre 1 y 100.
        public int CalcularEfectividad()
        {
            Random random = new Random();
            return random.Next(1, 101); // Genera un número aleatorio entre 1 y 100
        }

        //• Defensa: Armadura * Velocidad (del personaje que defiende)
        public int CalcularDefensa()
        {
            return Armadura * Velocidad; // Calcula la defensa multiplicando armadura por velocidad
        }

        // Método para actualizar la salud del personaje después de recibir daño
        public int ActualizarSalud(int danioProvocado)
        {
            
            Salud = Math.Max(0, Salud - danioProvocado); // Actualiza la salud
            return Salud; // Retorna la salud actualizada
        }

        // Método para calcular el daño infligido en un ataque
        public int Calculardanio(Habilidades habilidades)
        {
            int danio = (int)(((CalcularAtaque(habilidades) * CalcularEfectividad()) - CalcularDefensa()) / ConstanteAjuste); //Daño provocado

            return danio;
        }

        // Método para incrementar la salud del personaje (hasta un máximo de 100)
        public void ModificarSalud()
        {
            Salud = Math.Min(100, Salud + 10);
        }

        //==============================================================================================================================//
        /*
        Mecánica del Juego
                        5) El que gane es beneficiado con una mejora en sus habilidades. por ejemplo: +10 en salud o +5 en defensa.
                        Método para aumentar aleatoriamente una de las estadísticas del personaje
        */
        //==============================================================================================================================//
        
        
        public void AumentarEstadisticaAleatoria()
        {
            Random random = new Random();
            int estadistica = random.Next(1, 6); // Selecciona una estadística aleatoria (1-5)

            switch (estadistica)
            {
                case 1:
                    Velocidad = Math.Min(10, Velocidad + 1); // Aumenta la velocidad (máximo 10)
                    break;
                case 2:
                    destreza = Math.Min(5, destreza + 1); // Aumenta la defensa (máximo 10)
                    break;
                case 3:
                    Fuerza = Math.Min(10, Fuerza + 1); // Aumenta el Fuerza (máximo 10)
                    break;
                case 4:
                    Nivel = Math.Min(10, Nivel + 1); // Aumenta el Nivel (máximo 10)
                    break;
                case 5:
                    Armadura = Math.Min(10, Armadura + 1); // Aumenta el Armadura (máximo 10)
                    break;
            }
        }

        // Método para mostrar las estadísticas del personaje en la consola
        public void MostrarEstadisticas()
        {
            FuncionesUtiles.CentrarTexto($"Salud: {Salud}");
            FuncionesUtiles.CentrarTexto($"Velocidad: {Velocidad}");
            FuncionesUtiles.CentrarTexto($"Destreza: {Destreza}");
            FuncionesUtiles.CentrarTexto($"Fuerza: {Fuerza}");
            FuncionesUtiles.CentrarTexto($"Nivel: {Nivel}");
            FuncionesUtiles.CentrarTexto($"Armadura: {Armadura}");
        }
        //==============================================================================================================================//
    }
}
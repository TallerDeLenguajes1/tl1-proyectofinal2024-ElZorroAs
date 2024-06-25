using System;

namespace Personajes
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
            get => velocidad;
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
    }
    //==============================================================================================================================//
}

using System;

namespace Personajes
{
//==============================================================================================================================//
/*
1ra parte Generación de personaje:
Datos:
    velocidad;// 1 a 10
    destreza; //1 a 5
    fuerza;//1 a 10
    Nivel; //1 a 10
    Armadura; //1 a 10
    Salud://100
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
            set
            {
                if (value < 1 || value > 10)
                    throw new ArgumentOutOfRangeException("Velocidad debe estar entre 1 y 10.");
                velocidad = value;
            }
        }
        public int Destreza
        {
            get => destreza;
            set
            {
                if (value < 1 || value > 5)
                    throw new ArgumentOutOfRangeException("Destreza debe estar entre 1 y 5.");
                destreza = value;
            }
        }
        public int Fuerza
        {
            get => fuerza;
            set
            {
                if (value < 1 || value > 10)
                    throw new ArgumentOutOfRangeException("Fuerza debe estar entre 1 y 10.");
                fuerza = value;
            }
        }

        public int Nivel
        {
            get => nivel;
            set
            {
                if (value < 1 || value > 10)
                    throw new ArgumentOutOfRangeException("Nivel debe estar entre 1 y 10.");
                nivel = value;
            }
        }
        public int Armadura
        {
            get => armadura;
            set
            {
                if (value < 1 || value > 10)
                    throw new ArgumentOutOfRangeException("Armadura debe estar entre 1 y 10.");
                armadura = value;
            }
        }
        public int Salud
        {
            get => salud;
            private set { salud = value > 100 ? 100 : (value < 0 ? 0 : value); }
        }

        public void ReducirSalud(int cantidad)
        {
            Salud -= cantidad;
        }

        public void IncrementarSalud(int cantidad)
        {
            Salud += cantidad;
        }
    }
//==============================================================================================================================//
}

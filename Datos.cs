using System;

namespace Personajes
{
//==============================================================================================================================//
/*
1ra parte Generación de personaje:
Datos:
    Tipo;
    Nombre;
    Apodo;
    Fecha de Nacimiento;
    Edad;      //entre 0 a 300
*/
//==============================================================================================================================//
    public class Datos
    {
        private string tipo;
        private string nombre;
        private string apodo;
        private DateTime fechaDeNacimiento;
        private int edad; //entre 0 a 300

        public Datos(string tipo, string nombre, string apodo, DateTime fechaDeNacimiento, int edad)
        {
            this.Tipo = tipo;
            this.Nombre = nombre;
            this.Apodo = apodo;
            this.FechaDeNacimiento = fechaDeNacimiento;
            this.Edad = edad;
        }

        public string Tipo { get => tipo; set => tipo = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apodo { get => apodo; set => apodo = value; }
        public DateTime FechaDeNacimiento { get => fechaDeNacimiento; set => fechaDeNacimiento = value; }
        public int Edad 
        { 
            get => edad; 
            set 
            { 
                if (value < 0 || value > 300)
                    throw new ArgumentOutOfRangeException("Edad debe estar entre 0 y 300.");
                edad = value; 
            } 
        }
    }
//==============================================================================================================================//
}

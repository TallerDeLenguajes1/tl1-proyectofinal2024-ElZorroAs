using System;

namespace EspacioPersonaje
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
En Personaje.cs
- por qué crear una propiedad para editar los datos y características? es inseguro

En general vas muy bien. Bien estructurado, entendible y vas cumpliendo las rúbricas. Solo espero que sepas justificar todo si los profesores te consultan jaja
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

        public string Tipo { get => tipo; private set => tipo = value; }
        public string Nombre { get => nombre; private set => nombre = value; }
        public string Apodo { get => apodo; private set => apodo = value; }
        public DateTime FechaDeNacimiento { get => fechaDeNacimiento; private set => fechaDeNacimiento = value; }
        public int Edad { get => edad; private set => edad = value; }
    }
//==============================================================================================================================//
}

using System;
using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace EspacioPersonaje
{
//==============================================================================================================================//
/*
EXTRA:Habilidades
*/
//==============================================================================================================================//
    public class Habilidades
    {
        // Campos privados para almacenar los datos del Habilidades
        private string nombre;// Nombre del Habilidades

        private int ataque;//Ataque del Habilidades

        // Constructor vacío
        public Habilidades() { }

        // Constructor que inicializa todas las propiedades
        public Habilidades(string nombre, int Ataque)
        {
            this.Nombre = nombre;
            this.Ataque = Ataque;
        }
        // Propiedad para acceder al nombre del Habilidades
        [JsonInclude] // Atributo que indica que esta propiedad debe ser incluida en la serialización JSON
        public string Nombre { get => nombre; private set => nombre = value; }

        // Propiedad para acceder al tipo de ataque del Habilidades
        [JsonInclude]
        public int Ataque { get => ataque; private set => ataque = value; }
    }
//==============================================================================================================================//
}
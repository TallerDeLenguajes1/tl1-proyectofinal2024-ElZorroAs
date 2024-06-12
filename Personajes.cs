namespace Personajes;

// Importar las clases Datos y Caracteristicas
/*
using Personajes.Datos;
using Personajes.Caracteristicas;
*/

public class Personaje
{
    Datos datos;
    Caracteristicas caracteristicas;

    // Constructor para inicializar datos y características
    public Personaje(Datos datos, Caracteristicas caracteristicas)
    {
        this.Datos = datos;
        this.Caracteristicas = caracteristicas;
    }

    // Propiedades para acceder a los datos y características
    public Datos Datos
    {
        get => datos;
        set => datos = value;
    }

    public Caracteristicas Caracteristicas
    {
        get => caracteristicas;
        set => caracteristicas = value;
    }
}

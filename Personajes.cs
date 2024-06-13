namespace Personajes;
//==============================================================================================================================//
/*
1ra parte Generación de personaje:
*/
//==============================================================================================================================//
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
//==============================================================================================================================//
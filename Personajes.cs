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
//==============================================================================================================================//
    
    //==============================================================================================================================//
    /*
    2da parte Generación de valores aleatorios:
    */
    //==============================================================================================================================//

    // Método para mostrar la información del personaje en la consola
    public void MostrarInformacion(int i)
    {
    Console.WriteLine("\n\n\n\n\n\n\n\n\n");
    FuncionesUtiles.CentrarTexto("[========================================================================]");
    FuncionesUtiles.CentrarTexto($"[                              Personaje {i}                               ]");
    FuncionesUtiles.CentrarTexto("[========================================================================]");
    FuncionesUtiles.CentrarTexto($"Nombre del personaje: {Datos.Nombre}");
    FuncionesUtiles.CentrarTexto($"Tipo de personaje: {Datos.Tipo}");
    FuncionesUtiles.CentrarTexto($"Apodo del personaje: {Datos.Apodo}");
    FuncionesUtiles.CentrarTexto($"Fecha de nacimiento del personaje: {Datos.FechaDeNacimiento.ToShortDateString()}");
    FuncionesUtiles.CentrarTexto($"Edad del personaje: {Datos.Edad}");
    FuncionesUtiles.CentrarTexto($"Velocidad del personaje: {Caracteristicas.Velocidad}");
    FuncionesUtiles.CentrarTexto($"Destreza del personaje: {Caracteristicas.Destreza}");
    FuncionesUtiles.CentrarTexto($"Fuerza del personaje: {Caracteristicas.Fuerza}");
    FuncionesUtiles.CentrarTexto($"Nivel del personaje: {Caracteristicas.Nivel}");
    FuncionesUtiles.CentrarTexto($"Armadura del personaje: {Caracteristicas.Armadura}");
    FuncionesUtiles.CentrarTexto($"Salud del personaje: {Caracteristicas.Salud}");
    FuncionesUtiles.CentrarTexto("[========================================================================]");
    Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n");
    }
}
    //==============================================================================================================================//
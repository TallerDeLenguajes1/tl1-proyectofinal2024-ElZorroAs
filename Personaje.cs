namespace EspacioPersonaje;
//==============================================================================================================================//
/*
1ra parte Generación de personaje:
*/
//==============================================================================================================================//
public class Personaje
{
    Datos datos;
    Caracteristicas caracteristicas;
    //- por qué crear una propiedad para editar los datos y características? es inseguro
    // Constructor para inicializar datos y características
    public Personaje(Datos datos, Caracteristicas caracteristicas)
    {
        this.datos = datos;
        this.caracteristicas = caracteristicas;
    }

    // Propiedades para acceder a los datos y características
    public Datos Datos
    {
        get => datos;
        //set => datos = value;
    }
    public int Velocidad
    {
        get => caracteristicas.Velocidad;

    }

    public Caracteristicas Caracteristicas
    {
        get => caracteristicas;
        //set => caracteristicas = value;
    }
    //==============================================================================================================================//

    //==============================================================================================================================//
    /*
    2da parte Generación de valores aleatorios:
    */
    //==============================================================================================================================//

    // Método para mostrar la información del personaje en la consola
    public void MostrarInformacion()
    {
        Console.WriteLine("\n");
        FuncionesUtiles.CentrarTexto("[========================================================================]");
        FuncionesUtiles.CentrarTexto($"[                              Personaje                                ]");
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
        string detalles =" ";
        foreach (Habilidades habilidades in Datos.Habilidades)
        {
            detalles +=
                $"{habilidades.Nombre}:({habilidades.Ataque}), ";
        }
        FuncionesUtiles.CentrarTexto("[==============================[Habilidades]=============================]");
        FuncionesUtiles.CentrarTexto($"{detalles}");
        FuncionesUtiles.CentrarTexto("[========================================================================]");
        Console.WriteLine("\n");

    }

    public void MostrarInformacionContador(int i)
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
        string detalles =" ";
        foreach (Habilidades habilidades in Datos.Habilidades)
        {
            detalles +=
                $"{habilidades.Nombre}:({habilidades.Ataque}), ";
        }
        FuncionesUtiles.CentrarTexto("[==============================[Habilidades]=============================]");
        FuncionesUtiles.CentrarTexto($"{detalles}");
        FuncionesUtiles.CentrarTexto("[========================================================================]");
        Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n");
    }
    //==============================================================================================================================//
}
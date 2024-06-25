namespace Personajes
{
    public static partial class FuncionesUtiles
    {
        public static void CentrarTexto(string texto)
        {
            int screenWidth = Console.WindowWidth;
            int stringWidth = texto.Length;

            int espacios = (screenWidth - stringWidth) / 2;

            // Ajuste para la última línea del ASCII art
            if (texto.StartsWith("|___|"))
            {
                espacios--; // Ajuste adicional a la izquierda
            }

            Console.WriteLine(texto.PadLeft(espacios + stringWidth));
        }

         // Método para mostrar ASCII art de bienvenida con efecto de escritura
        public static void MostrarAsciiArtCentrado(string asciiArt)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;

            // Dividir el ASCII art en líneas
            string[] lines = asciiArt.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);

            // Mostrar cada línea centrada
            foreach (string line in lines)
            {
                CentrarTexto(line); // Llamada al método CentrarTexto dentro de la misma clase
                Thread.Sleep(50); // Pausa entre cada línea para simular escritura
            }

            Console.ResetColor();
            Console.WriteLine(); // Salto de línea al final del ASCII art
        }
    //Metodo para AsciiArt y que quede mas limpio el titulo
        public static void MostrarAsciiArtBienvenida(int opcion)
    {
        string asciiArt = "";

        switch (opcion)
        {
            case 1:
                asciiArt = @"
 _                  ____          _          _           
| |       __ _     / ___|  _ __  (_)   ___  | |_    __ _ 
| |      / _` |   | |  _  | '__| | |  / _ \ | __|  / _` |
| |___  | (_| |   | |_| | | |    | | |  __/ | |_  | (_| |
|_____|  \__,_|    \____| |_|    |_|  \___|  \__|  \__,_|
                ";

                break;
            case 2:
                asciiArt = @"
 ____           _ 
|  _ \    ___  | |
| | | |  / _ \ | |
| |_| | |  __/ | |
|____/   \___| |_|
                ";

                break;
            case 3:
                asciiArt = @"
 ___                                              _                
|_ _|  _ __   __   __   ___     ___    __ _    __| |   ___    _ __ 
 | |  | '_ \  \ \ / /  / _ \   / __|  / _` |  / _` |  / _ \  | '__|
 | |  | | | |  \ V /  | (_) | | (__  | (_| | | (_| | | (_) | | |   
|___| |_| |_|   \_/    \___/   \___|  \__,_|  \__,_|  \___/  |_|
                ";

                break;
            default:
                asciiArt = "Opción no válida.";
                break;
        }
        MostrarAsciiArtCentrado(asciiArt);
    }
    }
}

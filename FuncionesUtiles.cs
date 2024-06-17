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
        public static void MostrarAsciiArtBienvenida(string asciiArt)
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
    }
}

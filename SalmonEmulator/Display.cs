namespace SalmonEmulator;

public static class Display
{
    private static byte[,] displayBuffer = new byte[0xff,0x8f];
    public static void SetPixel(byte x, byte y, byte value)
    {
        displayBuffer[x, y] = value;
    }
    public static void PrintDisplay()
    {
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.CursorVisible = false;
        Console.SetCursorPosition(0, 0);

        //top border
        Console.Write("┌");
        for (byte x = 0; x < displayBuffer.GetLength(0); x++)
        {
            Console.Write("──");
        }
        Console.Write("┐");

        //Display Contents
        for (byte y = 0; y < displayBuffer.GetLength(1); y++)
        {
            Console.WriteLine();
            Console.Write("│");
            for (byte x = 0; x < displayBuffer.GetLength(0); x++)
            {
                Console.Write(displayBuffer[x, y] switch {  0 => "  ", 1 => "░░", 2 => "▒▒", 3 => "▓▓", 4 => "██", _ => "  "} );
            }
            Console.Write("│");

        }

        // bottom border
        Console.WriteLine();
        Console.Write("└");
        for (byte x = 0; x < displayBuffer.GetLength(0); x++)
        {
            Console.Write("──");
        }
        Console.Write("┘");
        Console.WriteLine();
        Console.CursorVisible = true;
        
    }


}
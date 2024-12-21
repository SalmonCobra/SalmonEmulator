namespace SalmonEmulator;

public static class Ports
{

    public static string UsePort(int port, bool isOut, string value)
    {
        if (isOut)
        {
            switch (port)
            {
                case 1:
                    Console.WriteLine(value);
                    break;
                case 10:
                    Display.SetPixel(Convert.ToByte((Convert.ToInt32(value) & 0xff000) >> 12), Convert.ToByte((Convert.ToInt32(value) & 0xff0) >> 4), Convert.ToByte(Convert.ToInt32(value) & 0xf));
                    break;
                case 11:
                    Display.PrintDisplay();
                    break;
                case 12:
                    Display.SetPixel(Convert.ToByte((Convert.ToInt32(value) & 0xff000) >> 12), Convert.ToByte((Convert.ToInt32(value) & 0xff0) >> 4), Convert.ToByte(Convert.ToInt32(value) & 0xf));
                    Display.PrintDisplay();
                    break;

            }
            return "";
        }
        else
        {
            string? input = "";
            switch (port)
            {
                case 1:
                    input = Console.ReadLine();
                    break;

            }
            return input != null ? input : "";
        }
    }
}
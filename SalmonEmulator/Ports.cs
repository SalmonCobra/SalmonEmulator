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
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;

namespace SalmonEmulator;
public class Emulator
{
    public static bool debug = true;
    public static int clockSpeed = 10;


    public static string[] Assembly = File.ReadAllLines(@"../../../Assembly.asm");
    public static void Main()
    {

        Tokenizer.Tokenize(Assembly);


    }


    
    

}
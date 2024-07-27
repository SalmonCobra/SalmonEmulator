using System.IO;

namespace SalmonEmulator
{
    partial class Emulator
    {
        private static string file = "C:\\Users\\Benjamin\\Documents\\Fork\\SalmonEmulator\\SalmonEmulator\\Assemblies\\Assembly.asm";
        static void Main(string[] args)
        {
            Assembler.LoadFile(file);
            
            Parser.Parse();
        }
    }
}

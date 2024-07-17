using System.IO;

namespace SalmonEmulator
{
    partial class Emulator
    {
        
        static void Main(string[] args)
        {
            string a = "mov [0x00ff], r0";
            Lexer lexer = new Lexer(a);
            while (true)
            {
                Token token = lexer.GetNextToken();
                TokenType type = token.type;
                string value = token.value;
                Console.WriteLine($"\"{type}\":\"{value}\"");
                if (type == TokenType.EOF) { break; }
                if (type == TokenType.ERROR) { break; } //throw new Exception(value);
            }

            
        }
    }
}

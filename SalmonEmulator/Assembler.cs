namespace SalmonEmulator
{
    public static class Assembler
    {
        static Assembler()
        {
            
        }

        public static void LoadFile(string FilePath)
        {
            if (File.Exists(FilePath))
            {
                Lexer.source = File.ReadAllText(FilePath);
            } 
            else 
            {
                throw new Exception("File Does Not Exsit");
            }
        }

        public static void Assemble()
        {
            List<Token> tokens = Lexer.GetTokens();
            foreach (Token token in tokens)
            {
                Console.WriteLine($"\"{token.type}\" :\"{token.value}\"");
            }
        }
    }
}
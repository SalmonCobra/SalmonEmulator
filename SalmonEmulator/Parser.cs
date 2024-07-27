using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalmonEmulator
{
    internal static class Parser
    {
        private static List<Token> tokens = Lexer.GetTokens();

        static Parser() {
            
        }

        private static int position = 0;
        private static List<Token> GetInstruction(List<Token> tokens)
        {
            List<Token> result = new List<Token>();

            while (position < tokens.Count && tokens[position] is { type: not TokenType.newline } token)
            {
                result.Add(token);
                position++;
            }
            if (position < tokens.Count)
            {
                position++;
            }
            return result;
        }

        public static void Parse()
        {
            tokens.RemoveAll(Token => Token.type == TokenType.whitespace);
            tokens.RemoveAll(Token => Token.type == TokenType.comma);
            tokens.RemoveAll(Token => Token.type == TokenType.comment);
            tokens.RemoveAll(Token => Token.type == TokenType.newline);

            foreach (var token in GetInstruction(tokens))
            {
                Console.WriteLine($"\"{token.type}\" : \"{token.value}\"");
            }



        }


    }

}

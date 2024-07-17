using Microsoft.Win32;
using System.Text.RegularExpressions;

namespace SalmonEmulator
{
    public class Lexer
    {
        private readonly string source;
        private int position;
        public Lexer(string source1)
        {
            source = source1;
            position = 0;
        }
        public uint line = 0;
        public Token GetNextToken()
        {
            // End Of File
            if (position == source.Length)
            {
                return new Token(TokenType.EOF, "EOF"); ;
            }

            // New Line
            if (source[position] == '\n')
            {
                position += 1;
                line++;
                return new Token(TokenType.newline, "newline");
            }

            // Comments
            if (source[position] == ';')
            {
                var comment = "";

                while (position < source.Length && !(source[position] == '\n'))
                {
                    comment += source[position];
                    position++;
                }
                return new Token(TokenType.comment, comment);
            }

            // Comma
            if (source[position] == ',')
            {
                position += 1;
                return new Token(TokenType.comma, ",");
            }

            // Whitespace
            if (Char.IsWhiteSpace(source[position]))
            {
                position += 1;
                //return new Token(TokenType.whitespace, " ");
            }

            // Numerics 
            if (char.IsNumber(source[position]))
            {
                var numeric = "";
                while (position < source.Length && !(source[position] == '\n'))
                {
                    numeric += source[position];
                    position++;
                }
                if (Regex.IsMatch(numeric, "^\\d+$|^0b[01]+$|^0x[0-9a-f]+$"))
                {
                    return new Token(TokenType.numeric, numeric);
                }
                else
                {
                    return new Token(TokenType.ERROR, $"Line {line}: Non-Numeric Type");
                }
            }

            // Registers
            if (source[position] == 'r')
            {
                var register = "";
                while (position < source.Length && !(source[position] == '\n'))
                {
                    register += source[position];
                    position++;
                }
                if (Regex.IsMatch(register, "^r[0-9]+$"))
                {
                    return new Token(TokenType.register, register);
                }
                else
                {
                    return new Token(TokenType.ERROR, $"Line {line}: Non-Numeric Type");
                }
            }

            //memPointer
            if (source[position] == '[')
            {
                var pointer = "";
                while ((position < source.Length && !(source[position] == '\n')) && !(source[position - 1] == ']'))
                {
                    pointer += source[position];
                    position++;
                }
                
                if (Regex.IsMatch(pointer, "^(\\[)(0x[0-9a-f]+|\\d+|0b[01]+)(])$"))
                {
                    return new Token(TokenType.memPointer, pointer);
                }
                else
                {
                    return new Token(TokenType.ERROR, $"Line {line}: Non-Numeric Type");
                }

            }







            if (source[position] == 'm' && source.AsSpan(position, 3).SequenceEqual("mov"))
            {
                position += 3;
                return new Token(TokenType.mov, "mov");
            }

            if (source[position] == 'l' && source.AsSpan(position, 2).SequenceEqual("ld"))
            {
                position += 2;
                return new Token(TokenType.ld, "ld");
            }

            if (source[position] == 'l' && source.AsSpan(position, 2).SequenceEqual("li"))
            {
                position += 2;
                return new Token(TokenType.ld, "li");
            }

            if (source[position] == 'a' && source.AsSpan(position, 3).SequenceEqual("add"))
            {
                position += 3;
                return new Token(TokenType.ld, "add");
            }


            return new Token(TokenType.ERROR, $"Line {line}: Unknown Token");
        }

    }
}

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

            // Memory Address
            if (source[position] == '[')
            {
                var address = "";
                while ((position < source.Length && !(source[position] == '\n')) && !(source[position - 1] == ']'))
                {
                    address += source[position];
                    position++;
                }
                
                if (Regex.IsMatch(address, "^(\\[)(0x[0-9a-f]+|\\d+|0b[01]+)(])$"))
                {
                    return new Token(TokenType.address, address);
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
                return new Token(TokenType.li, "li");
            }

            if (source[position] == 'a' && source.AsSpan(position, 3).SequenceEqual("add"))
            {
                position += 3;
                return new Token(TokenType.add, "add");
            }

            if (source[position] == 's' && source.AsSpan(position, 3).SequenceEqual("sub"))
            {
                position += 3;
                return new Token(TokenType.sub, "sub");
            }

            if (source[position] == 'a' && source.AsSpan(position, 3).SequenceEqual("and"))
            {
                position += 3;
                return new Token(TokenType.and, "and");
            }

            if (source[position] == 'o' && source.AsSpan(position, 3).SequenceEqual("or"))
            {
                position += 2;
                return new Token(TokenType.or, "or");
            }

            if (source[position] == 'e' && source.AsSpan(position, 3).SequenceEqual("xor"))
            {
                position += 3;
                return new Token(TokenType.xor, "xor");
            }

            if (source[position] == 's' && source.AsSpan(position, 3).SequenceEqual("shr"))
            {
                position += 3;
                return new Token(TokenType.shr, "shr");
            }

            if (source[position] == 's' && source.AsSpan(position, 3).SequenceEqual("shl"))
            {
                position += 3;
                return new Token(TokenType.shl, "shl");
            }

            if (source[position] == 'p' && source.AsSpan(position, 3).SequenceEqual("push"))
            {
                position += 4;
                return new Token(TokenType.push, "push");
            }

            if (source[position] == 'p' && source.AsSpan(position, 3).SequenceEqual("pop"))
            {
                position += 3;
                return new Token(TokenType.pop, "pop");
            }

            if (source[position] == 'p' && source.AsSpan(position, 3).SequenceEqual("peek"))
            {
                position += 4;
                return new Token(TokenType.peek, "peek");
            }

            if (source[position] == 'c' && source.AsSpan(position, 3).SequenceEqual("cmp"))
            {
                position += 3;
                return new Token(TokenType.cmp, "cmp");
            }

            if (source[position] == 'j' && source.AsSpan(position, 3).SequenceEqual("je"))
            {
                position += 2;
                return new Token(TokenType.je, "je");
            }

            if (source[position] == 'j' && source.AsSpan(position, 3).SequenceEqual("jne"))
            {
                position += 3;
                return new Token(TokenType.jne, "jne");
            }

            if (source[position] == 'j' && source.AsSpan(position, 3).SequenceEqual("jg"))
            {
                position += 2;
                return new Token(TokenType.jg, "jg");
            }

            if (source[position] == 'j' && source.AsSpan(position, 3).SequenceEqual("jge"))
            {
                position += 3;
                return new Token(TokenType.jge, "jge");
            }

            if (source[position] == 'j' && source.AsSpan(position, 3).SequenceEqual("jl"))
            {
                position += 2;
                return new Token(TokenType.jl, "jl");
            }

            if (source[position] == 'j' && source.AsSpan(position, 3).SequenceEqual("jle"))
            {
                position += 3;
                return new Token(TokenType.jle, "jle");
            }

            if (source[position] == 'c' && source.AsSpan(position, 3).SequenceEqual("call"))
            {
                position += 4;
                return new Token(TokenType.call, "call");
            }

            if (source[position] == 'r' && source.AsSpan(position, 3).SequenceEqual("ret"))
            {
                position += 3;
                return new Token(TokenType.ret, "ret");
            }

            if (source[position] == 'h' && source.AsSpan(position, 3).SequenceEqual("halt"))
            {
                position += 4;
                return new Token(TokenType.halt, "halt");
            }




            return new Token(TokenType.ERROR, $"Line {line}: Unknown Token");
        }

    }
}

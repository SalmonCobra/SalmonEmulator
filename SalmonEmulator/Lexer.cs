using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace SalmonEmulator
{
    public static class Lexer
    {
        public static string source = "";

        private static int position = 0;
        private static uint line = 0;

        private static Token ParseIdentifier()
        {
            var startPos = position;
            var pos = startPos + 1;

            var _source = source;

            while ((uint)pos < (uint)_source.Length)
            {
                var c = _source[pos];
                if (!char.IsAsciiLetter(c) && !char.IsAsciiDigit(c) && c != '_')
                {
                    break;
                }
                pos++;
            }
            position = pos;

            var text = _source[startPos..(pos - startPos)];
            return new Token(TokenType.Identifier, text);
        }

        
        private static Token GetNextToken()
        {


            if (source == null) { throw new Exception("No Source"); }





            // End Of File
            if (position >= source.Length)
            {
                return new Token(TokenType.EOF, "EOF"); ;
            }

            // New Line
            if (source[position] == '\n' || source[position] == '\r')
            {
                // Detect new line character and handle both \n and \r
                if (source[position] == '\n' || (source[position] == '\r' && (position + 1 >= source.Length || source[position + 1] != '\n')))
                {
                    position += 1;
                }
                else if (source[position] == '\r' && source[position + 1] == '\n')
                {
                    position += 2;
                }

                line++;
                return new Token(TokenType.newline, "newline");
            }

            // Lable
            if (source[position] == '_')
            {
                var label = "";
                while (position < source.Length && !(char.IsWhiteSpace(source[position]) || source[position].Equals(';')))
                {
                    label += source[position];
                    position++;
                }
                if (Regex.IsMatch(label, "^_[a-z]+"))
                {
                    return new Token(TokenType.label, label);
                }
                else
                {
                    return new Token(TokenType.ERROR, $"R: Line {line}: Non-Numeric Type");
                }
            }

            // Comments
            if (source[position] == ';')
            {
                var comment = "";

                while (position < source.Length && !(source[position] == '\n' || source[position] == '\r'))
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
            if (source[position].Equals(' ') || source[position].Equals('\t'))
            {
                position += 1;
                return new Token(TokenType.whitespace, " ");
            }

            // Numerics 
            if (char.IsNumber(source[position]))
            {
                var numeric = "";
                while (position < source.Length && !(char.IsWhiteSpace(source[position]) || source[position].Equals(',') || source[position].Equals(';')))
                {
                    numeric += source[position];
                    position++;
                }
                if (Regex.IsMatch(numeric, "^\\d+|^0b[01]+|^0x[0-9a-f]+"))
                {
                    return new Token(TokenType.numeric, numeric);
                }
                else
                {
                    return new Token(TokenType.ERROR, $"N: Line {line}: Non-Numeric Type");
                }
            }

            // Registers
            if (source[position] == 'r')
            {
                var register = "";
                while (position < source.Length && !(char.IsWhiteSpace(source[position]) || source[position].Equals(',') || source[position].Equals(';')))
                {
                    register += source[position];
                    position++;
                }
                if (Regex.IsMatch(register, "^r[0-9]+"))
                {
                    return new Token(TokenType.register, register);
                }
                else
                {
                    return new Token(TokenType.ERROR, $"R: Line {line}: Non-Numeric Type");
                }
            }

            // Memory Address
            if (source[position] == '[')
            {
                var address = "";
                while ((position < source.Length && !char.IsWhiteSpace(source[position]) && !(source[position - 1] == ']')))
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
                    return new Token(TokenType.ERROR, $"MA: Line {line}: Non-Numeric Type");
                }

            }

            if (source[position] == 'n' && source.AsSpan(position, 3).SequenceEqual("nop"))
            {
                position += 3;
                return new Token(TokenType.nop, "nop");
            }




            
            if (source[position] == 'n' && source.AsSpan(position, 3).SequenceEqual("nop"))
            {
                position += 3;
                return new Token(TokenType.nop, "nop");
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

            if (source[position] == 'p' && source.AsSpan(position, 4).SequenceEqual("push"))
            {
                position += 4;
                return new Token(TokenType.push, "push");
            }

            if (source[position] == 'p' && source.AsSpan(position, 3).SequenceEqual("pop"))
            {
                position += 3;
                return new Token(TokenType.pop, "pop");
            }

            if (source[position] == 'p' && source.AsSpan(position, 4).SequenceEqual("peek"))
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

            if (source[position] == 'c' && source.AsSpan(position, 4).SequenceEqual("call"))
            {
                position += 4;
                return new Token(TokenType.call, "call");
            }

            if (source[position] == 'r' && source.AsSpan(position, 3).SequenceEqual("ret"))
            {
                position += 3;
                return new Token(TokenType.ret, "ret");
            }

            if (source[position] == 'h' && source.AsSpan(position, 4).SequenceEqual("halt"))
            {
                position += 4;
                return new Token(TokenType.halt, "halt");
            }
            



            return new Token(TokenType.ERROR, $"Line {line}: Unknown Token");
        }
        

        public static List<Token> GetTokens()
        {
            List<Token> tokens = new();
            if (source != null)
            {
                while (Lexer.GetNextToken() is { type: not TokenType.EOF } token)
                {
                    tokens.Add(token);
                }
            }

            return tokens;
        }
        
    }
}

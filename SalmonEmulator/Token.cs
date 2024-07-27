using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalmonEmulator
{
    public enum TokenType
    {
        nop,
        ld,
        li,
        add,
        sub,
        and,
        or,
        xor,
        shr,
        shl,
        push,
        pop,
        peek,
        cmp,
        je,
        jne,
        jg,
        jge,
        jl,
        jle,
        call,
        ret,
        halt,


        label,
        register,
        numeric,
        address,
        comment,
        comma,
        whitespace,
        newline,
        Identifier,

        ERROR,
        EOF
    }
    public class Token
    {
        public TokenType type { get; }
        public string value { get; }
        public Token(TokenType Type, string Value) 
        {
            type = Type;
            value = Value;
        }
    }
}

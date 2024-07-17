using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalmonEmulator
{
    public static class Flags
    {
        public static uint Oprand1;
        public static uint Oprand2;

        public static bool zero = Register.GetRegister(Oprand1) == Register.GetRegister(Oprand2)  ? true : false ;
        public static bool sign = (Register.GetRegister(Oprand1) ^ Register.GetRegister(Oprand2)) >> 31 == 1 ? true : false;
        public static bool carry = (long)Register.GetRegister(Oprand1) + (long)Register.GetRegister(Oprand2) < Register.GetRegister(Oprand1) ? true : false;
    }
}

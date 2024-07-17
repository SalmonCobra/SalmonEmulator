namespace SalmonEmulator
{
    public static class Flags
    {
        public static uint Oprand1;
        public static uint Oprand2;

        private static bool zero;
        public static bool Zero 
        {
            get { return zero; }
            set { zero = Register.GetRegister(Oprand1) == Register.GetRegister(Oprand2); }
        }

        private static bool sign;
        public static bool Sign
        {
            get { return sign; }
            set { sign = (Register.GetRegister(Oprand1) ^ Register.GetRegister(Oprand2)) >> 31 == 1; }
        }

        private static bool carry;
        public static bool Carry
        {
            get { return carry; }
            set { carry = (long)Register.GetRegister(Oprand1) + (long)Register.GetRegister(Oprand2) < Register.GetRegister(Oprand1); }
        }
    }
}

namespace SalmonEmulator
{
    public static class Flags
    {
        public static uint Oprand1;
        public static uint Oprand2;

        public static bool Zero => Register.GetRegister(Oprand1) == Register.GetRegister(Oprand2);

        public static bool Sign => (Register.GetRegister(Oprand1) ^ Register.GetRegister(Oprand2)) >> 31 == 1;

        public static bool Carry => (long)Register.GetRegister(Oprand1) + (long)Register.GetRegister(Oprand2) < Register.GetRegister(Oprand1);
    }
}

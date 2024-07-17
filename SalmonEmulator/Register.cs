namespace SalmonEmulator
{
    internal static class Register
    {
        public static uint instructionPointer = 0;

        private static uint[] registers = new uint[16]; // defaults to 16
        public static void SetRegisterCount(uint registerCount) // will reset all register values! make priority!
        {
            registers = new uint[registerCount];
        }


        public static void LoadImmediate(uint register, uint value)
        {
            if (register < registers.Length)
            {
                registers[register] = value;
            }
            else
            {
                throw new IndexOutOfRangeException("Register Nonexistant");
            }
        }

        public static void Load(uint register1, uint register2)
        {
            if (register1 < registers.Length && register2 < registers.Length)
            {
                registers[register1] = registers[register2];
            }
            else
            {
                throw new IndexOutOfRangeException("Register Nonexistant");
            }
        }

        public static uint GetRegister(uint register)
        {
            if (register < registers.Length)
            {
                return registers[register];
            }
            else
            {
                throw new IndexOutOfRangeException("Register Nonexistant");
            }
        }
    }
}

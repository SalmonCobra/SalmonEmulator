using System.Text.RegularExpressions;

namespace SalmonEmulator
{
    public static class Instructions
    {

        public static void Add(uint source1, uint source2)
        {
            Register.LoadImmediate(0, source1 + source2);
        }

        public static void Subtract(uint source1, uint source2)
        {
            Register.LoadImmediate(0, source1 - source2);
        }

        public static void And(uint source1, uint source2)
        {
            Register.LoadImmediate(0, source1 & source2);
        }

        public static void Or(uint source1, uint source2)
        {
            Register.LoadImmediate(0, source1 | source2);
        }

        public static void ExclusiveOr(uint source1, uint source2)
        {
            Register.LoadImmediate(0, source1 ^ source2);
        }

        public static void RightShift(uint source1, uint source2)
        {
            Register.LoadImmediate(0, source1 >> (int)source2);
        }

        public static void LeftShift(uint source1, uint source2)
        {
            Register.LoadImmediate(0, source1 << (int)source2);
        }


        public static void LoadImmediate(string source1, uint source2)
        {
            if (Regex.IsMatch(source1, "(^\\[)(0x[0-9a-f]+)(]$)") || Regex.IsMatch(source1, "(^\\[)(0b[01]+)(]$)") || Regex.IsMatch(source1, "(^\\[)(\\d+)(]$)"))
            {
                Ram.Store((uint)Parsers.ParseAddress(source1), source2);
            } else if (Regex.IsMatch(source1, "^r[0-9]+$"))
            {
                Register.LoadImmediate((uint)Parsers.ParseRegister(source1), source2);
            }
        }




        public static void SetCompare(uint Oprand1, uint Oprand2)
        {
            Flags.Oprand1 = Oprand1;
            Flags.Oprand2 = Oprand2;
        }

        public static void JumpIfEqual(uint newAddress)
        {
            if (Flags.Zero)
            {
                Register.instructionPointer = newAddress;
            }
        }
        public static void JumpIfNotEqual(uint newAddress)
        {
            if (!Flags.Zero)
            {
                Register.instructionPointer = newAddress;
            }
        }
        public static void JumpIfGreater(uint newAddress)
        {
            if (!Flags.Sign && !Flags.Zero)
            {
                Register.instructionPointer = newAddress;
            }
        }
        public static void JumpIfGreaterOrEqual(uint newAddress)
        {
            if (!Flags.Sign)
            {
                Register.instructionPointer = newAddress;
            }
        }
        public static void JumpIfLess(uint newAddress)
        {
            if (Flags.Sign && !Flags.Zero)
            {
                Register.instructionPointer = newAddress;
            }
        }
        public static void JumpIfLessOrEqual(uint newAddress)
        {
            if (Flags.Sign)
            {
                Register.instructionPointer = newAddress;
            }
        }

        public static void Call(uint subroutineAddress)
        {
            Stack.Push(Register.instructionPointer++);
            Register.instructionPointer = subroutineAddress;
        }

        public static void Return()
        {
            Register.instructionPointer = Stack.Pop();
        }
    }
}

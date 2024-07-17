namespace SalmonEmulator
{
    
    public static class Stack
    {
        public static uint stackPointer { get; private set; } = 0;
        private static uint[] stackValue = new uint[16]; // defaults to 16
        
        
        public static void SetProperties(uint stackSize)
        {
            stackValue = new uint[stackSize];
        }


        public static void Push(uint value)
        {
            if (stackPointer != stackValue.Length)
            {
                stackValue[stackPointer] = value;
                stackPointer++;
            }
            else
            {
                throw new InvalidOperationException("Stack Overflow");
            }

        }
        public static uint Pop()
        {
            if (stackPointer != 0)
            {
                stackPointer--;
                var value = stackValue[stackPointer];
                return value;
            }
            else
            {
                throw new InvalidOperationException("Stack Underflow");
            }
        }
        public static uint Peek()
        {
            if (stackPointer != 0)
            {
                return stackValue[stackPointer - 1];
            }
            else
            {
                throw new InvalidOperationException("Stack Empty");
            }
        }
    }
}

namespace SalmonEmulator;

public static class NativeStack
{
    private static Stack<int> stack = new();

    public static void Push(int value)
    {
        stack.Push(value);
    }
    public static int Peek()
    {
        return stack.Peek();
    }
    public static int Pop()
    {
        return stack.Pop();
    }
}
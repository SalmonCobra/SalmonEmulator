using System.Drawing;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;

namespace SalmonEmulator;

public static class Ram
{
    public const int length = 2048;



    private static int[] data = new int[length];
    private static Instruction[] instruction = new Instruction[length];



    public static void SetInstruction(int index, Instruction i)
    {
        instruction[index] = i;
    }
    public static void SetData(string index, int d)
    {
        data[Convert.ToInt32(index)] = d;
    }


    public static (Instruction, int) GetMemory(int index)
    {
        return (instruction[index], data[index]);
    }

    public static Instruction GetInstruction(int index)
    {
        return instruction[index];
    }

    public static int GetData(string index)
    {
        return data[Convert.ToInt32(index)];
    }
}
using System.Dynamic;
using System.Reflection.Metadata;

namespace SalmonEmulator;

public static class Registers
{
    private static int[] registers = new int[31];
    private static Dictionary<string, bool> flags = new Dictionary<string, bool> {
        {"sign", false},
        {"zero", false},
        {"carry", false},
        {"overflow", false},
        {"interrupt", false}
    };
    public static int GetRegister(string index)
    {
        return registers[Convert.ToInt32(index) - 1]; // convert to one indexed
    }
    public static bool GetFlag(string flag)
    {
        return flags[flag];
    }
    

    public static void SetRegister(string index, int value)
    {
        registers[Convert.ToInt32(index) - 1] = value; // convert to one indexed
    }

    public static void SetFlag(string flag, bool value)
    {
        flags[flag] = value;
    }

}
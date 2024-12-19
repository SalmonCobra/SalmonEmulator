namespace SalmonEmulator;
public class InstructionData
{

    private Action<string[]>? method;
    private string name = "";
    private int clockCycles = 0;
    private List<Token.TokenType> argumentOneRules = new();
    private List<Token.TokenType> argumentTwoRules = new();
    private List<Token.TokenType> argumentThreeRules = new();

    public Action<string[]>? Method
    {
        get { return method; }
        set { method = value; }
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public int ClockCycles
    {
        get { return clockCycles; }
        set { clockCycles = value; }
    }

    public List<Token.TokenType> ArgumentOneRules
    {
        get { return argumentOneRules; }
        set { argumentOneRules = value; }
    }

    public List<Token.TokenType> ArgumentTwoRules
    {
        get { return argumentTwoRules; }
        set { argumentTwoRules = value; }
    }

    public List<Token.TokenType> ArgumentThreeRules
    {
        get { return argumentThreeRules; }
        set { argumentThreeRules = value; }
    }

}

public static class Instructions
{
    public static bool CheckTypes(Token.TokenType tokenType, List<Token.TokenType> listType)
    {
        foreach (Token.TokenType type in listType)
        {
            if (tokenType == type)
            {
                return true;
            }
        }
        return false;
    }

    public static List<InstructionData> instructionRegistry = new();

    public static (bool, InstructionData) SearchRegistry(string instruction)
    {
        foreach (InstructionData instructionData in instructionRegistry)
        {
            if (instructionData.Name == instruction)
            {
                return (true, instructionData);
            }
        }
        return (false, new InstructionData());
    }

    public static List<Token.TokenType> CreateArgumentRules(params Token.TokenType[] args)
    {
        List<Token.TokenType> argumentRules = new(args);
        return argumentRules;
    }
    public static void RegisterInstruction(Action<string[]> method, string name, int clockCycles, List<Token.TokenType> argumentOneRules, List<Token.TokenType> argumentTwoRules, List<Token.TokenType> argumentThreeRules)
    {
        InstructionData instructionData = new();
        instructionData.Method = method;
        instructionData.Name = name;
        instructionData.ClockCycles = clockCycles;
        instructionData.ArgumentOneRules = argumentOneRules;
        instructionData.ArgumentTwoRules = argumentTwoRules;
        instructionData.ArgumentThreeRules = argumentThreeRules;
        instructionRegistry.Add(instructionData);
    }



    public static void Nop(params string[] args)
    {
        foreach (string arg in args)
        {
            Console.WriteLine(arg);
        }
    }
    public static void Ld(params string[] args)
    {
        Console.WriteLine("ld");
        foreach (string arg in args)
        {
            Console.WriteLine(arg);
        }
    }


    public static Action<string[]> nop = Nop;
    public static Action<string[]> ld = Ld;
    static Instructions()
    {
        // register instructions here
        RegisterInstruction(nop, "nop", 2, CreateArgumentRules(Token.TokenType.None), CreateArgumentRules(Token.TokenType.None), CreateArgumentRules(Token.TokenType.None));
        RegisterInstruction(ld, "ld", 7, CreateArgumentRules(Token.TokenType.Register), CreateArgumentRules(Token.TokenType.Numeric), CreateArgumentRules(Token.TokenType.None));
    }
}

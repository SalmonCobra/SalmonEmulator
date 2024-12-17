namespace SalmonEmulator;
public class InstructionData
{

    private Action<string[]>? method;
    private string name = "";
    private int clockCycles = 0;
    private List<ArgumentTypes> argumentOneRules = new();
    private List<ArgumentTypes> argumentTwoRules = new();
    private List<ArgumentTypes> argumentThreeRules = new();
    public enum ArgumentTypes : byte
    {
        none,
        numeric,
        register,
    }

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

    public List<ArgumentTypes> ArgumentOneRules
    {
        get { return argumentOneRules; }
        set { argumentOneRules = value; }
    }

    public List<ArgumentTypes> ArgumentTwoRules
    {
        get { return argumentTwoRules; }
        set { argumentTwoRules = value; }
    }

    public List<ArgumentTypes> ArgumentThreeRules
    {
        get { return argumentThreeRules; }
        set { argumentThreeRules = value; }
    }

}

public static class Instructions
{

    public static List<InstructionData> instructionRegistry = new();

    public static List<InstructionData.ArgumentTypes> CreateArgumentRules(params InstructionData.ArgumentTypes[] args)
    {
        List<InstructionData.ArgumentTypes> argumentRules = new(args);
        return argumentRules;
    }
    public static void RegisterInstruction(Action<string[]> method, string name, int clockCycles, List<InstructionData.ArgumentTypes> argumentOneRules, List<InstructionData.ArgumentTypes> argumentTwoRules, List<InstructionData.ArgumentTypes> argumentThreeRules)
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
        
    }
    public static void Ld(params string[] args)
    {

    }


    public static Action<string[]> nop = Nop;
    public static Action<string[]> ld = Ld;
    static Instructions()
    {
        // register instructions here
        RegisterInstruction(nop, "nop", 2, CreateArgumentRules(InstructionData.ArgumentTypes.none), CreateArgumentRules(InstructionData.ArgumentTypes.none), CreateArgumentRules(InstructionData.ArgumentTypes.none));
        RegisterInstruction(ld, "ld", 7, CreateArgumentRules(InstructionData.ArgumentTypes.register), CreateArgumentRules(InstructionData.ArgumentTypes.numeric), CreateArgumentRules(InstructionData.ArgumentTypes.none));
    }
}

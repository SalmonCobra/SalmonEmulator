using System.Diagnostics.CodeAnalysis;
using System.Reflection.Metadata.Ecma335;

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
public class Instruction
{
    private Action<string[]>? method;
    private string[] arguments = ["", "", ""];
    private int clockCycles = 2;

    public Action<string[]>? Method
    {
        get { return method; }
        set { method = value; }
    }

    public string[] Arguments
    {
        get { return arguments; }
        set { arguments = value; }
    }

    public int ClockCycles
    {
        get { return clockCycles; }
        set { clockCycles = value; }
    }
}

public static class Instructions
{

    public static void ValidateAndExtractArgument(int line, int arg, InstructionData instructionData, string[] arguments)
    {
        if (Tokenizer.instructions[line].Count >= arg + 1)
        {
            if (CheckTypes(Tokenizer.instructions[line][arg].type, arg switch { 1 => instructionData.ArgumentOneRules, 2 => instructionData.ArgumentTwoRules, 3 => instructionData.ArgumentThreeRules, _ => CreateArgumentRules(Token.TokenType.None) }))
            {
                // arguments is zero indexed, arg is 1 indexed
                arguments[arg - 1] = Tokenizer.instructions[line][arg].content;
            }
            else
            {
                throw new Exception($"Instruction '{instructionData.Name}' on line {line + 1} Doesnt Accept Type '{Tokenizer.instructions[line][arg].type}'");
            }
        }
    }

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

    }
    public static void Halt(params string[] args)
    {
        Emulator.halted = true;
        Emulator.skipIncrement = true;
    }

    public static void Out(params string[] args)
    {
        string a = Parsers.TryParseRegister(args[1]).ToString();
        Ports.UsePort(Convert.ToInt32(args[0]), true, a);
    }

    public static void In(params string[] args)
    {
        string a = "";
        Ports.UsePort(Convert.ToInt32(args[0]), false, a);
        Registers.SetRegister(Parsers.GetRegisterId(args[1]), Convert.ToInt32(a));
    }

    public static void Ldi(params string[] args)
    {
        Registers.SetRegister(Parsers.GetRegisterId(args[0]), Convert.ToInt32(args[1]));

    }

    public static void Ld(params string[] args)
    {
        Registers.SetRegister(Parsers.GetRegisterId(args[0]), Ram.GetData(args[1]));

    }

    public static void St(params string[] args)
    {
        Ram.SetData(args[0], Registers.GetRegister(Parsers.GetRegisterId(args[1])));

    }

    public static void Push(params string[] args)
    {
        NativeStack.Push(Parsers.TryParseRegister(args[1]));
    }

    public static void Pop(params string[] args)
    {
        Registers.SetRegister(Parsers.GetRegisterId(args[0]), NativeStack.Pop());
    }

    public static void Peek(params string[] args)
    {
        Registers.SetRegister(Parsers.GetRegisterId(args[0]), NativeStack.Peek());
    }

    public static void Add(params string[] args)
    {
        int a = Registers.GetRegister(Parsers.GetRegisterId(args[0]));
        int b = Parsers.TryParseRegister(args[1]);
        int sum = a + b;


        Registers.SetRegister(Parsers.GetRegisterId(args[0]), sum);
        Registers.SetFlag("zero", sum == 0);
        Registers.SetFlag("sign", sum < 0);
        Registers.SetFlag("overflow", (a > 0 && b > int.MaxValue - a) || (a < 0 && b < int.MinValue - a));
        Registers.SetFlag("carry", (uint)a + (uint)b < (uint)a);

    }

    public static void Sub(params string[] args)
    {
        int a = Registers.GetRegister(Parsers.GetRegisterId(args[0]));
        int b = Parsers.TryParseRegister(args[1]);
        int sum = a + b * -1;

        Registers.SetRegister(Parsers.GetRegisterId(args[0]), sum);
        Registers.SetFlag("zero", sum == 0);
        Registers.SetFlag("sign", sum < 0);
        Registers.SetFlag("overflow", (a > 0 && b > int.MaxValue - a) || (a < 0 && b < int.MinValue - a));
        Registers.SetFlag("carry", (uint)a + (uint)b < (uint)a);

    }
    public static void Shl(params string[] args)
    {
        int a = Registers.GetRegister(Parsers.GetRegisterId(args[0]));
        int b = Parsers.TryParseRegister(args[1]);
        bool msb = (a & 1 << 31) != 0;
        int product = a << b;

        Registers.SetFlag("zero", product == 0);
        Registers.SetFlag("sign", product < 0);
        Registers.SetFlag("overflow", (a & 1 << 31) != 0 != msb);
        Registers.SetFlag("carry", (a & (1 << (31 - b))) != 0);

        Registers.SetRegister(Parsers.GetRegisterId(args[0]), product);
    }
    public static void Shr(params string[] args)
    {
        int a = Registers.GetRegister(Parsers.GetRegisterId(args[0]));
        int b = Parsers.TryParseRegister(args[1]);
        int product = a >> b;
        //(value & (1 << (shiftAmount - 1))) != 0);
        Registers.SetFlag("zero", product == 0);
        Registers.SetFlag("sign", product < 0);
        Registers.SetFlag("overflow", false);
        Registers.SetFlag("carry", (a & (1 << (b - 1))) != 0);

        Registers.SetRegister(Parsers.GetRegisterId(args[0]), product);
    }
    public static void And(params string[] args)
    {
        int a = Registers.GetRegister(Parsers.GetRegisterId(args[0]));
        int b = Parsers.TryParseRegister(args[1]);
        int answer = a & b;


        Registers.SetRegister(Parsers.GetRegisterId(args[0]), answer);
    }

    public static void Or(params string[] args)
    {
        int a = Registers.GetRegister(Parsers.GetRegisterId(args[0]));
        int b = Parsers.TryParseRegister(args[1]);
        int answer = a | b;


        Registers.SetRegister(Parsers.GetRegisterId(args[0]), answer);
    }

    public static void Xor(params string[] args)
    {
        int a = Registers.GetRegister(Parsers.GetRegisterId(args[0]));
        int b = Parsers.TryParseRegister(args[1]);
        int answer = a ^ b;


        Registers.SetRegister(args[0], answer);
    }

    public static void Not(params string[] args)
    {
        int a = Registers.GetRegister(Parsers.GetRegisterId(args[0]));
        Registers.SetRegister(args[0], ~a);
    }

    public static void Call(params string[] args)
    {
        NativeStack.Push(Emulator.programCounter);
        Emulator.skipIncrement = true;
    }
    public static void Ret(params string[] args)
    {
        Emulator.programCounter = NativeStack.Pop();
        Emulator.skipIncrement = true;
    }

    public static void Cmp(params string[] args)
    {
        int a = Registers.GetRegister(Parsers.GetRegisterId(args[0]));
        int b = Parsers.TryParseRegister(args[1]);
        int sum = a + b * -1;

        Registers.SetFlag("zero", sum == 0);
        Registers.SetFlag("sign", sum < 0);
        Registers.SetFlag("overflow", (a > 0 && b > int.MaxValue - a) || (a < 0 && b < int.MinValue - a));
        Registers.SetFlag("carry", (uint)a + (uint)b < (uint)a);

    }

    public static void Jmp(params string[] args)
    {
        Emulator.programCounter = Convert.ToInt32(args[0]);
        Emulator.skipIncrement = true;
    }

    public static void Jeq(params string[] args)
    {
        if (Registers.GetFlag("zero"))
        {
            Emulator.programCounter = Convert.ToInt32(args[0]);
            Emulator.skipIncrement = true;
        }
    }

    public static void Jne(params string[] args)
    {
        if (!Registers.GetFlag("zero"))
        {
            Emulator.programCounter = Convert.ToInt32(args[0]);
            Emulator.skipIncrement = true;
        }
    }

    public static void Jgt(params string[] args)
    {
        if (!Registers.GetFlag("zero") && !Registers.GetFlag("sign"))
        {
            Emulator.programCounter = Convert.ToInt32(args[0]);
            Emulator.skipIncrement = true;
        }
    }

    public static void Jge(params string[] args)
    {
        if (Registers.GetFlag("zero") || !Registers.GetFlag("sign"))
        {
            Emulator.programCounter = Convert.ToInt32(args[0]);
            Emulator.skipIncrement = true;
        }
    }

    public static void Jlt(params string[] args)
    {
        if (!Registers.GetFlag("zero") && Registers.GetFlag("sign"))
        {
            Emulator.programCounter = Convert.ToInt32(args[0]);
            Emulator.skipIncrement = true;
        }
    }

    public static void Jle(params string[] args)
    {
        if (Registers.GetFlag("zero") || Registers.GetFlag("sign"))
        {
            Emulator.programCounter = Convert.ToInt32(args[0]);
            Emulator.skipIncrement = true;
        }
    }

    public static Action<string[]> nop = Nop;
    public static Action<string[]> halt = Halt;
    public static Action<string[]> _out = Out;
    public static Action<string[]> _in = In;
    public static Action<string[]> ldi = Ldi;
    public static Action<string[]> ld = Ld;
    public static Action<string[]> st = St;
    public static Action<string[]> push = Push;
    public static Action<string[]> pop = Pop;
    public static Action<string[]> peek = Peek;
    public static Action<string[]> add = Add;
    public static Action<string[]> sub = Sub;
    public static Action<string[]> shl = Shl;
    public static Action<string[]> shr = Shr;
    public static Action<string[]> and = And;
    public static Action<string[]> or = Or;
    public static Action<string[]> xor = Xor;
    public static Action<string[]> not = Not;
    public static Action<string[]> call = Call;
    public static Action<string[]> ret = Ret;
    public static Action<string[]> cmp = Cmp;
    public static Action<string[]> jmp = Jmp;
    public static Action<string[]> jeq = Jeq;
    public static Action<string[]> jne = Jne;
    public static Action<string[]> jgt = Jgt;
    public static Action<string[]> jge = Jge;
    public static Action<string[]> jlt = Jlt;
    public static Action<string[]> jle = Jle;
    static Instructions()
    {
        // register instructions here
        // RegisterInstruction(<Delegate>, <name>, <clockCycles>, <argumentRulesList>, <argumentRulesList>, <argumentRulesList>);
        RegisterInstruction(nop, "nop", 2,
        CreateArgumentRules(Token.TokenType.None),
        CreateArgumentRules(Token.TokenType.None),
        CreateArgumentRules(Token.TokenType.None));

        RegisterInstruction(halt, "halt", 2,
        CreateArgumentRules(Token.TokenType.None),
        CreateArgumentRules(Token.TokenType.None),
        CreateArgumentRules(Token.TokenType.None));

        RegisterInstruction(_out, "out", 2,
        CreateArgumentRules(Token.TokenType.Numeric),
        CreateArgumentRules(Token.TokenType.Register, Token.TokenType.Numeric),
        CreateArgumentRules(Token.TokenType.None));

        RegisterInstruction(_in, "in", 2,
        CreateArgumentRules(Token.TokenType.Numeric),
        CreateArgumentRules(Token.TokenType.Register),
        CreateArgumentRules(Token.TokenType.None));

        RegisterInstruction(ldi, "ldi", 3,
        CreateArgumentRules(Token.TokenType.Register),
        CreateArgumentRules(Token.TokenType.Numeric),
        CreateArgumentRules(Token.TokenType.None));

        RegisterInstruction(ld, "ld", 7,
        CreateArgumentRules(Token.TokenType.Register),
        CreateArgumentRules(Token.TokenType.Numeric),
        CreateArgumentRules(Token.TokenType.None));

        RegisterInstruction(st, "st", 6,
        CreateArgumentRules(Token.TokenType.Numeric),
        CreateArgumentRules(Token.TokenType.Register),
        CreateArgumentRules(Token.TokenType.None));

        RegisterInstruction(push, "push", 2,
        CreateArgumentRules(Token.TokenType.Numeric, Token.TokenType.Register),
        CreateArgumentRules(Token.TokenType.None),
        CreateArgumentRules(Token.TokenType.None));

        RegisterInstruction(pop, "pop", 2,
        CreateArgumentRules(Token.TokenType.Register),
        CreateArgumentRules(Token.TokenType.None),
        CreateArgumentRules(Token.TokenType.None));

        RegisterInstruction(peek, "peek", 2,
        CreateArgumentRules(Token.TokenType.Register),
        CreateArgumentRules(Token.TokenType.None),
        CreateArgumentRules(Token.TokenType.None));

        RegisterInstruction(add, "add", 2,
        CreateArgumentRules(Token.TokenType.Register),
        CreateArgumentRules(Token.TokenType.Register, Token.TokenType.Numeric),
        CreateArgumentRules(Token.TokenType.None));

        RegisterInstruction(sub, "sub", 2,
        CreateArgumentRules(Token.TokenType.Register),
        CreateArgumentRules(Token.TokenType.Register, Token.TokenType.Numeric),
        CreateArgumentRules(Token.TokenType.None));

        RegisterInstruction(shl, "shl", 2,
        CreateArgumentRules(Token.TokenType.Register),
        CreateArgumentRules(Token.TokenType.Register, Token.TokenType.Numeric),
        CreateArgumentRules(Token.TokenType.None));

        RegisterInstruction(shr, "shr", 2,
        CreateArgumentRules(Token.TokenType.Register),
        CreateArgumentRules(Token.TokenType.Register, Token.TokenType.Numeric),
        CreateArgumentRules(Token.TokenType.None));

        RegisterInstruction(and, "and", 2,
        CreateArgumentRules(Token.TokenType.Register),
        CreateArgumentRules(Token.TokenType.Register, Token.TokenType.Numeric),
        CreateArgumentRules(Token.TokenType.None));

        RegisterInstruction(or, "or", 2,
        CreateArgumentRules(Token.TokenType.Register),
        CreateArgumentRules(Token.TokenType.Register, Token.TokenType.Numeric),
        CreateArgumentRules(Token.TokenType.None));

        RegisterInstruction(xor, "xor", 2,
        CreateArgumentRules(Token.TokenType.Register),
        CreateArgumentRules(Token.TokenType.Register, Token.TokenType.Numeric),
        CreateArgumentRules(Token.TokenType.None));

        RegisterInstruction(not, "not", 2,
        CreateArgumentRules(Token.TokenType.Register),
        CreateArgumentRules(Token.TokenType.Register, Token.TokenType.Numeric),
        CreateArgumentRules(Token.TokenType.None));

        RegisterInstruction(call, "call", 2,
        CreateArgumentRules(Token.TokenType.None),
        CreateArgumentRules(Token.TokenType.None),
        CreateArgumentRules(Token.TokenType.None));

        RegisterInstruction(ret, "ret", 2,
        CreateArgumentRules(Token.TokenType.None),
        CreateArgumentRules(Token.TokenType.None),
        CreateArgumentRules(Token.TokenType.None));

        RegisterInstruction(cmp, "cmp", 2,
        CreateArgumentRules(Token.TokenType.Register),
        CreateArgumentRules(Token.TokenType.Register, Token.TokenType.Numeric),
        CreateArgumentRules(Token.TokenType.None));

        RegisterInstruction(jmp, "jmp", 2,
        CreateArgumentRules(Token.TokenType.Numeric),
        CreateArgumentRules(Token.TokenType.None),
        CreateArgumentRules(Token.TokenType.None));

        RegisterInstruction(jeq, "jeq", 2,
        CreateArgumentRules(Token.TokenType.Numeric),
        CreateArgumentRules(Token.TokenType.None),
        CreateArgumentRules(Token.TokenType.None));

        RegisterInstruction(jne, "jne", 2,
        CreateArgumentRules(Token.TokenType.Numeric),
        CreateArgumentRules(Token.TokenType.None),
        CreateArgumentRules(Token.TokenType.None));

        RegisterInstruction(jgt, "jgt", 2,
        CreateArgumentRules(Token.TokenType.Numeric),
        CreateArgumentRules(Token.TokenType.None),
        CreateArgumentRules(Token.TokenType.None));

        RegisterInstruction(jge, "jge", 2,
        CreateArgumentRules(Token.TokenType.Numeric),
        CreateArgumentRules(Token.TokenType.None),
        CreateArgumentRules(Token.TokenType.None));

        RegisterInstruction(jlt, "jlt", 2,
        CreateArgumentRules(Token.TokenType.Numeric),
        CreateArgumentRules(Token.TokenType.None),
        CreateArgumentRules(Token.TokenType.None));

        RegisterInstruction(jle, "jle", 2,
        CreateArgumentRules(Token.TokenType.Numeric),
        CreateArgumentRules(Token.TokenType.None),
        CreateArgumentRules(Token.TokenType.None));

    }
}



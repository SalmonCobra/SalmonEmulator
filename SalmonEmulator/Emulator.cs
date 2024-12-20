using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace SalmonEmulator;
public class Emulator
{

    public static bool debug = true;
    public static int clockSpeed = 50;
    public static int programCounter = 0;
    public static bool skipIncrement = false;
    public static bool halted = false;

    public static string[] Assembly = File.ReadAllLines(@"assemblies/Assembly.asm");
    public static void Main()
    {
        Tokenizer.Tokenize(Assembly);

        StoreProgramToMemory();

        RunProgram();
        

    }

    private static void StoreProgramToMemory()
    {
        for (int l = 0; l < Tokenizer.instructions.Count; l++)
        {
            string instruction;
            InstructionData instructionData;
            string[] arguments = ["", "", ""];

            if (Tokenizer.instructions[l][0].type == Token.TokenType.Instruction)
            {
                instruction = Tokenizer.instructions[l][0].content;
                (bool Success, instructionData) = Instructions.SearchRegistry(instruction);
                if (!Success)
                {
                    throw new Exception($"line {l + 1}: Instruction Not Registered");
                }

                Instructions.ValidateAndExtractArgument(l, 1, instructionData, arguments);
                Instructions.ValidateAndExtractArgument(l, 2, instructionData, arguments);
                Instructions.ValidateAndExtractArgument(l, 3, instructionData, arguments);

                Instruction i = new Instruction();
                i.ClockCycles = instructionData.ClockCycles;
                i.Arguments = arguments;
                i.Method = instructionData.Method;
                Ram.SetInstruction(l, i);

            }
            if (Tokenizer.instructions[l][0].type == Token.TokenType.Numeric)
            {
                if (Tokenizer.instructions[l].Count == 1)
                {
                    Ram.SetData(l.ToString(), Convert.ToInt32(Tokenizer.instructions[l][0].content));
                }
                else
                {
                    throw new Exception($"Something is not right on line {l + 1}");
                }

            }
        }
    }

    private static void RunProgram()
    {

        while (halted == false && programCounter < Ram.length)
        {


            Instruction i = Ram.GetInstruction(programCounter);
            if (i != null)
            {
                if (clockSpeed != 0)
                {
                    Thread.Sleep(1000 / clockSpeed * i.ClockCycles);
                }

                i.Method?.Invoke(i.Arguments);
            }
            else
            {
                if (clockSpeed != 0)
                {
                    Thread.Sleep(1000 / clockSpeed * 2);
                }
            }
            if (!skipIncrement)
            {
                programCounter++;
            } 
            skipIncrement = false;
        }
        if (halted)
        {
            //Console.WriteLine("The Program Has Halted");
        }

    }

}
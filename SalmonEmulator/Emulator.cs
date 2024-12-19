using System.IO;
using System.Reflection;

namespace SalmonEmulator;
public class Emulator
{
    public static bool debug = true;
    public static int clockSpeed = 2;


    //public static string[] Assembly = File.ReadAllLines(@"../../../assemblies/Assembly.asm");
    public static string[] Assembly = File.ReadAllLines(@"assemblies/Assembly.asm");
    public static void Main()
    {

        Tokenizer.Tokenize(Assembly);
        //Tokenizer.PrintInstructions();

        for (int l = 0; l < Tokenizer.instructions.Count; l++)
        {
            string instruction = "";
            InstructionData instructionData = new();
            string[] arguments = { "", "", "" };

            if (Tokenizer.instructions[l][0].type == Token.TokenType.Instruction)
            {
                instruction = Tokenizer.instructions[l][0].content;
                (bool Success, instructionData) = Instructions.SearchRegistry(instruction);
                if (!Success)
                {
                    throw new Exception("Instruction Not Registered");
                }
            }
            if (Tokenizer.instructions[l].Count >= 2)
            {
                var a = Tokenizer.instructions[l].Count;
                if (Instructions.CheckTypes(Tokenizer.instructions[l][1].type, instructionData.ArgumentOneRules))
                {
                    arguments[0] = Tokenizer.instructions[l][1].content;
                }
                else
                {
                    throw new Exception($"Instruction '{instructionData.Name}' on line {l + 1} Doesnt Accept Type '{Tokenizer.instructions[l][1].type}'");
                }
            }
            if (Tokenizer.instructions[l].Count >= 3)
            {
                if (Instructions.CheckTypes(Tokenizer.instructions[l][2].type, instructionData.ArgumentTwoRules))
                {
                    arguments[1] = Tokenizer.instructions[l][2].content;
                }
                else
                {
                    throw new Exception($"Instruction '{instructionData.Name}' on line {l + 1} Doesnt Accept Type '{Tokenizer.instructions[l][2].type}'");
                }
            }

            if (Tokenizer.instructions[l].Count >= 4)
            {
                if (Instructions.CheckTypes(Tokenizer.instructions[l][3].type, instructionData.ArgumentThreeRules))
                {
                    arguments[2] = Tokenizer.instructions[l][3].content;
                }
                else
                {
                    throw new Exception($"Instruction '{instructionData.Name}' on line {l + 1} Doesnt Accept Type '{Tokenizer.instructions[l][3].type}'");
                }

            }

            Thread.Sleep(1000 / clockSpeed * instructionData.ClockCycles);
            instructionData.Method?.Invoke(arguments);
        }


    }





}
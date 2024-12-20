using System.Diagnostics;

namespace SalmonEmulator;

public static class Tokenizer
{
    // a dictionary where the key is the name of the label, and the pair is the address leading the address of the label
    public static Dictionary<string, int> labels = new();

    // A list where each element is an array of tokens
    public static List<List<Token>> instructions = new();



    public static void Tokenize(string[] line)
    {
        char[] delimiters = { ' ', ',' };
        int labelCount = 0;
        List<string> filteredLine = new();

        //------------------------------------------------------------------------------Labels And Whitespace-------------------------------------------------------------------------------
        for (int l = 0; l < line.Length; l++)
        {

            // If there's a comment in the line, trim it off before processing.
            int commentIndex = line[l].IndexOf(';');
            if (commentIndex >= 0)
            {
                line[l] = line[l][0..commentIndex];  // Keep only the code before the comment
            }

            var empty = false;
            string[] splitLine = line[l].Split(delimiters, StringSplitOptions.RemoveEmptyEntries); // these get reset each line
            for (int w = 0; w < splitLine.Length; w++)
            {
                if (w == 0 && Parsers.IsLabel(splitLine[w]))  // if the first word is a label
                {
                    labels.Add(splitLine[w], (l - labelCount)); // subtracting labelCount from L to make up for the difference when theres no lines for labels.      NOTE!!! NEW LINES MAY BREAK THIS     Consider removing whitespace from the input of everything.
                    labelCount++;
                    empty = true;
                }
            }
            if (line[l].All(char.IsWhiteSpace))
            {
                empty = true;
                labelCount++;
            }

            if (!empty)
            {
                filteredLine.Add(line[l]);
            }
        }

        //-------------------------------------------------------------------------------Tokenize everything else ----------------------------------------------------------------------------------------
        for (int l = 0; l < filteredLine.Count; l++)
        {
            List<Token> tokens = new(); //---------------------------------------------------------// these get reset each line


            string[] splitLine = filteredLine[l].Split(delimiters, StringSplitOptions.RemoveEmptyEntries); // these get reset each line

            for (int w = 0; w < splitLine.Length; w++)
            {
                Token token = new Token();
                //--------------------------------------------------------------Instructions------------------------------------------------
                if (w == 0 && !Parsers.IsNumeric(splitLine[w]) && splitLine[w].All(char.IsLetter)) // if its the first word, and its not a label nor a number, its probably safe to say its an instruction.
                {
                    token.type = Token.TokenType.Instruction;
                    token.content = splitLine[w];
                    tokens.Add(token);
                }

                //--------------------------------------------------------------Numerics----------------------------------------------------
                if (Parsers.IsNumeric(splitLine[w])) // if its a numeric create a numeric token
                {
                    token.type = Token.TokenType.Numeric;
                    token.content = Parsers.ConvertNumeric(splitLine[w]);
                    tokens.Add(token);
                }

                //--------------------------------------------------------------Registers---------------------------------------------------
                if (w >= 1 && Parsers.IsRegister(splitLine[w])) // if its greater than the first word, and the parser says its a register... its mostlikely a register...
                {
                    token.type = Token.TokenType.Register;
                    token.content = splitLine[w];
                    tokens.Add(token);
                }

                //--------------------------------------------------------------Label Addresses----------------------------------------------
                if (w >= 1 && !Parsers.IsRegister(splitLine[w]) && splitLine[w].Any(char.IsLetter))  // if its greater than the first word, and everything is letters, its probably a label. p r o b a b l y . . .
                {
                    if (labels.TryGetValue(splitLine[w] + ":", out int value)) // check if its in the label dictionary, and if its not well... TOO BAD FOR YOU LOLOL.
                    {
                        token.type = Token.TokenType.Numeric;
                        token.content = value.ToString();
                    }
                    else
                    {
                        throw new Exception("That Label Doesnt Exist...");
                    }
                    tokens.Add(token);
                }

            }
            instructions.Add(tokens); // this goes right befor the end bracket of the first for loop, to save tokens to instructions

        }
    }





    public static void PrintInstructions()
    {
        Console.WriteLine("\n---Labels---\n");
        foreach (KeyValuePair<string, int> keyValuePair in labels)
        {
            Console.WriteLine($"{keyValuePair.Key} {keyValuePair.Value}");
        }
        Console.WriteLine("\n---Contents---\n");
        foreach (List<Token> i in instructions)
        {
            foreach (Token t in i)
            {
                Console.Write($"{t.content} ");
            }
            Console.WriteLine();
        }
        Console.WriteLine("\n---Type---\n");
        foreach (List<Token> i in instructions)
        {
            foreach (Token t in i)
            {
                Console.Write($"{t.type} ");
            }
            Console.WriteLine();
        }
    }



}

public class Token
{
    public enum TokenType
    {
        None,
        Instruction,
        Register,
        Numeric
    }
    private TokenType _type;
    private string _content = "";

    public TokenType type
    {
        get { return _type; }
        set { _type = value; }
    }
    public string content
    {
        get { return _content; }
        set { _content = value; }
    }
}


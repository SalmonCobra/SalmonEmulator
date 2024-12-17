using System.Transactions;

namespace SalmonEmulator;

public static class Tokenizer
{
    // a dictionary where the key is the name of the label, and the pair is the address leading the address of the label
    public static Dictionary<string, int> labels = new();

    // A list where each element is an array of tokens
    public static List<List<Token>> instructions = new();



    public static void Tokenize(string[] line)
    {
        Console.WriteLine("Starting Tokenizing");

        char[] delimiters = { ' ', ',' };
        int labelCount = 0;
        List<string> filteredLine = new();


        //------------------------------------------------------------------------------Labels And Whitespace-------------------------------------------------------------------------------
        for (int l = 0; l < line.Length; l++)
        {
            var empty = false;
            string[] splitLine = line[l].Split(delimiters, StringSplitOptions.RemoveEmptyEntries); // these get reset each line
            for (int w = 0; w < splitLine.Length; w++)
            {
                if (w == 0 && Parsers.IsLabel(splitLine[w]))  // if the first word is a label
                {
                    labels.Add(splitLine[w], (l - labelCount) - 1); // subtracting labelCount from L to make up for the difference when theres no lines for labels.      NOTE!!! NEW LINES MAY BREAK THIS     Consider removing whitespace from the input of everything.
                    labelCount++;
                    empty = true;
                } 
            }
            if (line[l].All(char.IsWhiteSpace))
            {
                empty = true;
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
            for (int w = 0; w < splitLine.Length ; w++)
            {
                Token token = new Token();
                //--------------------------------------------------------------Instructions------------------------------------------------
                if (w == 0 && !Parsers.IsNumeric(splitLine[w]) && splitLine[w].All(char.IsLetter)) // if its the first word, and its not a label nor a number, its probably safe to say its an instruction.
                {
                    token.type = Token.TokenType.Instruction;
                    token.content = splitLine[w];
                    token.line = l;
                    tokens.Add(token);
                }
                //--------------------------------------------------------------Instructions------------------------------------------------

                //--------------------------------------------------------------Numerics----------------------------------------------------
                if (Parsers.IsNumeric(splitLine[w])) // if its a numeric create a numeric token
                {
                    token.type = Token.TokenType.Numeric;
                    token.content = Parsers.ConvertNumeric(splitLine[w]);
                    token.line = l;
                    tokens.Add(token);
                }
                //--------------------------------------------------------------Numerics----------------------------------------------------

                //--------------------------------------------------------------Registers---------------------------------------------------
                if (w >= 1 && Parsers.IsRegister(splitLine[w])) // if its greater than the first word, and the parser says its a register... its mostlikely a register...
                {
                    token.type = Token.TokenType.Register;
                    token.content = Parsers.GetRegisterId(splitLine[w]);
                    token.line = l;
                    tokens.Add(token);
                }
                //--------------------------------------------------------------Registers----------------------------------------------------

                //--------------------------------------------------------------Label Addresses----------------------------------------------
                if (w >= 1 && splitLine[w].All(char.IsLetter))  // if its greater than the first word, and everything is letters, its probably a label. p r o b a b l y . . .
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
                    token.line = l;
                    tokens.Add(token);
                }
                //--------------------------------------------------------------Label Addresses-----------------------------------------------
            }
            instructions.Add(tokens); // this goes right befor the end bracket of the first for loop, to save tokens to instructions
        }


        // --------------------------------------------debug
        /*
        Console.WriteLine("\nContents:");
        foreach (List<Token> l in instructions)
        {
            foreach (Token t in l)
            {
                Console.Write(t.content + " ");
            }
            Console.WriteLine();
        }
        Console.WriteLine("\nType:");
        foreach (List<Token> l in instructions)
        {
            foreach (Token t in l)
            {
                Console.Write(t.type + " ");
            }
            Console.WriteLine();
        }
        Console.WriteLine("\nLine:");
        foreach (List<Token> l in instructions)
        {
            foreach (Token t in l)
            {
                Console.Write(t.line + " ");
            }
            Console.WriteLine();
        }
*/
        Console.WriteLine("Tokenizing Complete");
        // --------------------------------------------debug
    }


}

public class Token
{
    public enum TokenType
    {
        none,
        Instruction,
        Register,
        Numeric
    }
    private TokenType _type;
    private string _content = "";
    private int _line = 0;

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
    public int line
    {
        get { return _line; }
        set { _line = value; }
    }
}


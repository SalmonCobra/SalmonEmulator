namespace SalmonEmulator;

public static class Parsers
{
    // helpers
    public static bool IsLabel(string input)
    {
        // check if the string contains any letters at all, then check if it ends with a colon.
        return input.Any(char.IsLetter) && input.EndsWith(":");
    }
    public static bool IsRegister(string input)
    {
        // check if the first letter is r, then check if the remaining characters are numerics.
        return input.StartsWith("r") && input.Substring(1, input.Length - 1).All(char.IsDigit);
    }
    public static bool IsDecNumeric(string input)
    {
        return input.All(char.IsDigit);
    }
    public static bool IsHexNumeric(string input)
    {
        return input.StartsWith("0x") && (input.Substring(2, input.Length - 2).All(char.IsDigit) || input.Substring(2, input.Length - 2).All(char.IsLetter));
    }
    public static bool IsBinNumeric(string input)
    {
        return input.StartsWith("0b") && input.Substring(2, input.Length - 2).All(char.IsDigit);
    }
    public static bool IsNumeric(string input)
    {
        // figure it out yourself...
        return IsBinNumeric(input) || IsHexNumeric(input) || IsDecNumeric(input);
    }
    
    
    // actual parsers
    public static string ConvertNumeric(string input)
    {
        // if its a numeric already in base 10 just return it... theres no work to be done here...
        if (IsDecNumeric(input))
        {
            return input;
        }

        // if its binary convert the characters leading "0b" into base 10
        if (IsBinNumeric(input))
        {
            return Convert.ToInt32(input.Substring(2, input.Length - 2), 2).ToString();
        }

        // if its hexadecimal convert the characters leading "0x" into base 10
        if (IsHexNumeric(input))
        {
            return Convert.ToInt32(input.Substring(2, input.Length - 2), 16).ToString();
        }

        // and if the user was just so stupid that he couldnt even figure out what a number was before he tried to convert CRAP into one, throw an exception.
        throw new Exception("Failed to Convert Numeric");
    }
    public static string GetRegisterId(string input)
    {
        if (IsRegister(input))
        {
            return input.Substring(1, input.Length - 1);
        }
        throw new Exception("not a register");
    }

}
using System.Text.RegularExpressions;

namespace SalmonEmulator
{
    public static class Parsers
    {
        public static int ParseBinary(string binary)
        {
            int result = 0;
            if (Regex.IsMatch(binary, "^0b[01]+$"))
            {
                binary = binary.AsSpan(1, binary.Length).ToString();
                
                result = Convert.ToInt32(binary, 2);
            }
            return result;
        }

        public static int ParseHex(string hex)
        {
            int result = 0;
            if (Regex.IsMatch(hex, "^0x[0-9a-f]+$"))
            {
                hex = hex.AsSpan(2, hex.Length - 2).ToString();

                result = Convert.ToInt32(hex, 16);
            }
            return result;
        }

        public static int ParseToInt32(string numeric)
        {
            if (Regex.IsMatch(numeric, "^0x[0-9a-f]+$"))
            {
                return ParseHex(numeric);
            }
            else if (Regex.IsMatch(numeric, "^0b[01]+$"))
            {
                return ParseBinary(numeric);
            }
            else if(Regex.IsMatch(numeric, "\\d+"))
            {
                return int.Parse(numeric);
            }
            throw new Exception("Non Numeric Type");
        }

        public static int ParseAddress(string address)
        {
            int result = 0;
            address = address.AsSpan(1, address.Length - 2).ToString();
            result = ParseToInt32(address);
            return result;
        }

        public static int ParseRegister(string register)
        {
            int result = 0;
            register = register.AsSpan(1, register.Length - 1).ToString();
            result = ParseToInt32(register);
            return result;
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalmonEmulator
{
    public static class Ram
    {
        private static uint[] value = new uint[2048000];

        public static void SetRamSize(uint size)
        {
            value = new uint[size];
        }

        public static void Store(uint location, uint newValue)
        {
            if (location < value.Length)
            {
                value[location] = newValue;
            }
            else
            {
                throw new IndexOutOfRangeException("Memory Location Nonexistant");
            }
            
        }
        public static uint Load(uint location)
        {
            if (location < value.Length)
            {
                return value[location];
            }
            else
            {
                throw new IndexOutOfRangeException("Memory Location Nonexistant");
            }
        }
    }
}

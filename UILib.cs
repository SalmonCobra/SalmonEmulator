using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalmonEmulator
{
    public static class UILib
    {
        public static int MenuSelect(string[] menuItems)
        {
            int itemSelected = 0;
            while (true)
            {
                Console.WriteLine();
                for (int i = 0; i < menuItems.Length; i++)
                {
                    Console.WriteLine((itemSelected == i ? " [-] " : " [ ] ") + menuItems[i]);
                }

                ConsoleKey key = Console.ReadKey().Key;

                if (key == ConsoleKey.Enter)
                {
                    
                    return itemSelected;
                }
                if (key == ConsoleKey.UpArrow)
                {
                    itemSelected -= 1;
                }
                else if (key == ConsoleKey.DownArrow)
                {
                    itemSelected += 1;
                }
                itemSelected = Math.Clamp(itemSelected, 0, menuItems.Length);

                Console.SetCursorPosition(0, 0);
            }
        }
    }
}

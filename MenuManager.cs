using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    internal class MenuManager
    {
        public int ShowLevelMenu()
        {

            string[] levels = { "Kerge tase", "Keskmine tase", "Raske tase" };
            int selected = 0;

            int mapWidth = 80;
            int menuMaxWidth = levels.Max(l => l.Length);
            int startX = (mapWidth - menuMaxWidth - 2) / 2;
            int startY = 11;

            Utility.ClearContentArea(mapWidth, 25);

            string prompt = "Vali raskusaste:";
            int promptX = (mapWidth - prompt.Length) / 2;
            Console.SetCursorPosition(promptX, startY - 2);
            Utility.AnimateText(prompt, 30);

            ConsoleKey key;

            do
            {
                for (int i = 0; i < levels.Length; i++)
                {
                    Console.SetCursorPosition(startX, startY + i);
                    if (i == selected)
                    {
                        Console.BackgroundColor = ConsoleColor.Cyan;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write($"> {levels[i]} ");
                    }
                    else
                    {
                        Console.ResetColor();
                        Console.Write($"  {levels[i]} ");
                    }
                }

                key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.UpArrow)
                    selected = (selected - 1 + levels.Length) % levels.Length;
                else if (key == ConsoleKey.DownArrow)
                    selected = (selected + 1) % levels.Length;

            } while (key != ConsoleKey.Enter);

            Console.ResetColor();
            return selected + 1;
        }
    }
}

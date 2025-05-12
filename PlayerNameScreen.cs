using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    internal class PlayerNameScreen
    {
        public static string Show(int mapWidth = 80)
        {
            Console.Clear();

            string prompt = "Sisesta oma nimi:";
            int promptX = (mapWidth - prompt.Length) / 2;
            int inputX = (mapWidth - 30) / 2; // ориентировочно 30 символов на ввод
            int startY = 12;

            Console.SetCursorPosition(promptX, startY - 2);
            Console.ForegroundColor = ConsoleColor.Gray;
            Utility.AnimateText(prompt);

            Console.SetCursorPosition(inputX, startY);
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("> ");
            Console.ResetColor();

            Console.SetCursorPosition(inputX + 2, startY);
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.ForegroundColor = ConsoleColor.Black;
            string name = Console.ReadLine();
            Console.ResetColor();
            return name;
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    internal class GameOver
    {
        public static void ShowGameOverPanel(int score, string playerName, int mapWidth = 80)
        {
            string title = " GAME OVER ";
            string scoreLine = $" Skoor: {score}";
            string nameLine = $" Mängija: {playerName}";

            int panelWidth = Math.Max(Math.Max(title.Length, scoreLine.Length), nameLine.Length) + 8;
            int startX = (mapWidth - panelWidth) / 2;
            int startY = 10;

            Console.ForegroundColor = ConsoleColor.Cyan;

            // Верхняя рамка
            Console.SetCursorPosition(startX, startY);
            Console.Write("╔" + new string('═', panelWidth - 2) + "╗");

            // Заголовок
            Console.SetCursorPosition(startX, startY + 1);
            Console.Write("║");
            Console.ForegroundColor = ConsoleColor.White;
            foreach (char c in title)
            {
                Console.Write(c);
                Thread.Sleep(60);
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(new string(' ', panelWidth - 2 - title.Length));
            Console.Write("║");

            // Разделительная линия
            Console.SetCursorPosition(startX, startY + 2);
            Console.Write("╠" + new string('═', panelWidth - 2) + "╣");

            // Счёт
            Console.SetCursorPosition(startX, startY + 3);
            Console.Write("║");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(scoreLine);
            Console.Write(new string(' ', panelWidth - 2 - scoreLine.Length));
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("║");

            // Имя игрока
            Console.SetCursorPosition(startX, startY + 4);
            Console.Write("║");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(nameLine + " ");
            Console.Write(new string(' ', panelWidth - 2 - nameLine.Length - 1)); // учли пробел
            Console.Write("║");

            // Нижняя рамка
            Console.SetCursorPosition(startX, startY + 5);
            Console.Write("╚" + new string('═', panelWidth - 2) + "╝");

            Console.ResetColor();

            // Вывод надписи под рамкой, по центру
            string pressKeyLine = "Vajuta klahvi...";
            int promptX = (mapWidth - pressKeyLine.Length) / 2;
            Console.SetCursorPosition(promptX, startY + 7);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(pressKeyLine);
            Console.ResetColor();

            Console.ReadKey();
        }
    }
}

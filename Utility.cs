using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    internal class Utility
    {
        // Метод для очистки внутренней части рамки
        public static void ClearContentArea(int mapWidth, int mapHeight)
        {
            for (int y = 1; y < mapHeight - 1; y++)
            {
                Console.SetCursorPosition(1, y);
                Console.Write(new string(' ', mapWidth - 2));
            }
        }

        public static void AnimateText(string text, int delayMs = 15)
        {
            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(delayMs);
            }
            Console.WriteLine();
        }

        public static void DrawTopPanel(int score, string playerName, int width = 80)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;

            // Верхняя рамка панели
            
            Console.SetCursorPosition(0, 1);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($" Mängija: {playerName}");

            Console.ForegroundColor = ConsoleColor.Yellow;
            string scoreText = $"Punktid: {score} ";
            int padding = width - 2 - $" Mängija: {playerName}".Length - scoreText.Length;

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(new string(' ', padding));
            Console.Write(scoreText);

            Console.ResetColor();
        }
    }
}

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

        public static void DrawTopPanel(int score, string playerName, int currentSpeed, int width = 80)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.SetCursorPosition(0, 1);
            string playerText = $" Mängija: {playerName}";
            string scoreText = $"Punktid: {score}";
            string speedText = $"Kiirus: {currentSpeed}ms";

            int padding = width - 2 - playerText.Length - scoreText.Length - speedText.Length;
            if (padding < 0) padding = 0;

            Console.Write(playerText);
            Console.Write(new string(' ', padding / 2));
            Console.Write(scoreText);
            Console.Write("  " + speedText);

            Console.ResetColor();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    internal class MenuManager
    {
        public int ShowMainMenu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("=== ЗМЕЙКА ===");
            Console.ResetColor();
            Console.WriteLine("\n1. Играть");
            Console.WriteLine("2. Показать рекорды");
            Console.WriteLine("3. Выйти");
            Console.Write("\nВыберите пункт: ");

            int choice = 0;
            while (true)
            {
                string input = Console.ReadLine();
                if (int.TryParse(input, out choice) && choice >= 1 && choice <= 3)
                    break;
                Console.Write("Введите число 1-3: ");
            }
            return choice;
        }

        public int ShowLevelMenu()
        {
            Console.Clear();
            Console.WriteLine("Выберите уровень сложности:");
            Console.WriteLine("1. Лёгкий 🐢");
            Console.WriteLine("2. Средний 🐍");
            Console.WriteLine("3. Сложный ⚡");
            Console.Write("\nВаш выбор: ");

            int level = 0;
            while (true)
            {
                string input = Console.ReadLine();
                if (int.TryParse(input, out level) && level >= 1 && level <= 3)
                    break;
                Console.Write("Введите число 1-3: ");
            }
            return level;
        }
        private void AnimatedPrint(string text, int delayMs = 15)
        {
            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(delayMs);
            }
            Console.WriteLine();
        }
    }
}

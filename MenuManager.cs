using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    internal class MenuManager
    {
        // Метод для отображения меню и обработки выбора стрелками
        public int ShowMenu()
        {
            ConsoleKey key; // Переменная для хранения нажатой клавиши
            int menuMaxWidth = menuItems.Max(item => item.Length);
            int menuStartX = (mapWidth - menuMaxWidth - 2) / 2;
            int menuStartY = logoStartY + logoHeight + 2;
            do
            {
                // Перерисовываем все пункты меню
                for (int i = 0; i < menuItems.Length; i++)
                {
                    Console.SetCursorPosition(menuStartX, menuStartY + i); // Позиция каждой строки
                    if (i == selectedIndex)
                    {
                        // Если это выбранный пункт, выделяем цветом и добавляем стрелку
                        Console.BackgroundColor = ConsoleColor.Cyan;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write($"> {menuItems[i]} ");
                    }
                    else
                    {
                        // Обычный (невыбранный) пункт
                        Console.ResetColor();
                        Console.Write($"  {menuItems[i]} ");
                    }
                }

                // Читаем, какую клавишу нажал пользователь
                key = Console.ReadKey(true).Key;

                // Обработка клавиш
                if (key == ConsoleKey.UpArrow)
                    selectedIndex = (selectedIndex - 1 + menuItems.Length) % menuItems.Length;
                else if (key == ConsoleKey.DownArrow)
                    selectedIndex = (selectedIndex + 1) % menuItems.Length;

            }
            while (key != ConsoleKey.Enter); // Выходим из цикла, когда нажата клавиша Enter

            Console.ResetColor();       // Убираем подсветку
            return selectedIndex + 1;   // Возвращаем номер выбранного пункта (от 1 до 3)
        }

        public int ShowLevelMenu()
        {
            string[] levels = { "Лёгкий 🐢", "Средний 🐍", "Сложный ⚡" };
            int selected = 0;

            int menuWidth = levels.Max(l => l.Length);
            int startX = (80 - menuWidth - 2) / 2;
            int startY = 12;

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
            return selected + 1; // вернёт 1..3
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

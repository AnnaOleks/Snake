using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    // Класс отвечает за отображение титульного экрана и меню
    internal class TitleScreen
    {
        // Массив с пунктами главного меню
        private string[] menuItems = { "Mängima", "Rekordid", "Välju" };
        // Индекс выбранного пункта меню (по умолчанию — первый)
        private int selectedIndex = 0;

        private int mapWidth;
        private int mapHeight;

        private int logoStartY = 7;
        private int logoHeight = 6;

        public TitleScreen(int width, int height)
        {
            mapWidth = width;
            mapHeight = height;
        }

        // Метод, который отображает титульный экран и возвращает выбранный пункт
        public int Show()
        {
            Utility.ClearContentArea(80, 25);  // очищаем центр

            // Массив строк для логотипа SNACE (ASCII-art)
            string[] logo = new string[]
            {
                "███████╗███╗   ██╗ █████╗ ██╗  ██╗███████╗",
                "██╔════╝████╗  ██║██╔══██╗██║ ██╔╝██╔════╝",
                "███████╗██╔██╗ ██║███████║█████╔╝ █████╗  ",
                "╚════██║██║╚██╗██║██╔══██║██╔═██╗ ██╔══╝  ",
                "███████║██║ ╚████║██║  ██║██║  ██╗███████╗",
                "╚══════╝╚═╝  ╚═══╝╚═╝  ╚═╝╚═╝  ╚═╝╚══════╝"
            };

            Console.ForegroundColor = ConsoleColor.Cyan;

            // Рисуем логотип начиная с позиции x=20, y=4
            int logoWidth = logo[0].Length;
            int logoStartX = (mapWidth - logoWidth) / 2;

            for (int i = 0; i < logo.Length; i++)
            {
                Console.SetCursorPosition(logoStartX, logoStartY + i);
                Console.WriteLine(logo[i]);
            }

            Console.ResetColor();

            AnimateMenu(); // анимация меню

            return ShowMenu();
        }
      

        // Метод анимированного вывода названия
        private void AnimateMenu()
        {
            int menuMaxWidth = menuItems.Max(item => item.Length);
            int menuStartX = (mapWidth - menuMaxWidth - 2) / 2; // отступ на "> " слева
            int menuStartY = logoStartY + logoHeight + 2; // немного ниже логотипа

            for (int i = 0; i < menuItems.Length; i++)
            {
                Console.SetCursorPosition(menuStartX, menuStartY + i); // ниже логотипа
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write($"  {menuItems[i]} ");
                Thread.Sleep(200); // задержка перед каждой строкой
            }
        }


        // Метод для отображения меню и обработки выбора стрелками
        private int ShowMenu()
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
    }
}


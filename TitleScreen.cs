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
        public string[] menuItems = { "Mängima", "Rekordid", "Välju" };
        // Индекс выбранного пункта меню (по умолчанию — первый)
        public int selectedIndex = 0;

        public int mapWidth;
        public int mapHeight;

        public int logoStartY = 7;
        public int logoHeight = 6;

        public TitleScreen(int width, int height)
        {
            mapWidth = width;
            mapHeight = height;
        }

        // Метод, который отображает титульный экран и возвращает выбранный пункт
        public int Show()
        {
            ClearContentInsideFrame();  // очищаем центр

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
        private void ClearContentInsideFrame()
        {
            // Очищаем только то, что внутри рамки 
            for (int y = 1; y < mapHeight - 1; y++) // строки
            {
                Console.SetCursorPosition(1, y);   // отступ от левого края рамки
                Console.Write(new string(' ', mapWidth - 2));
            }
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


        
    }
}


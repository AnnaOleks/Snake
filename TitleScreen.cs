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

        // Метод, который отображает титульный экран и возвращает выбранный пункт
        public int Show()
        {
            ClearContentInsideFrame();                  // очищаем только внутреннюю часть рамки
            AnimateTitle("SNACE", 34, 5);    // анимированно рисуем заголовок
            return ShowMenu();                          // запускаем стрелочное меню
        }

        private void ClearContentInsideFrame()
        {
            // Очищаем только то, что внутри рамки 
            for (int y = 3; y < 22; y++) // строки
            {
                Console.SetCursorPosition(3, y);   // отступ от левого края рамки
                Console.Write(new string(' ', 77));
            }
        }

        // Метод анимированного вывода названия
        private void AnimateTitle(string title, int x, int y)
        {
            Console.SetCursorPosition(x, y);                // Переходим в нужную позицию
            Console.ForegroundColor = ConsoleColor.Cyan;    // Задаём цвет текста
            
            // Постепенно выводим каждую букву
            foreach (char c in title)
            {
                Console.Write(c);                   // Выводим букву
                Thread.Sleep(200);  // задержка анимации
            }
            Console.ResetColor(); // Сбрасываем цвет
        }


        // Метод для отображения меню и обработки выбора стрелками
        private int ShowMenu()
        {
            ConsoleKey key; // Переменная для хранения нажатой клавиши

            do
            {
                // Перерисовываем все пункты меню
                for (int i = 0; i < menuItems.Length; i++)
                {
                    Console.SetCursorPosition(30, 6 + i); // Позиция каждой строки
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


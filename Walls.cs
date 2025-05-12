using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Walls
    {
        List<Figure> wallList;

        public Walls(int mapWidth, int mapHeight)
        {
            wallList = new List<Figure>();

            Console.ForegroundColor = ConsoleColor.Cyan;

            // Горизонтальная линия сверху и снизу
            HorizontalLine topLine = new HorizontalLine(0, mapWidth, 0, '═');
            HorizontalLine bottomLine = new HorizontalLine(0, mapWidth, mapHeight-1, '═');

            // Вертикальная линия слева и справа
            VerticalLine leftLine = new VerticalLine(0, mapHeight, 0, '║');
            VerticalLine rightLine = new VerticalLine(0, mapHeight, mapWidth, '║');

            wallList.Add(topLine);
            wallList.Add(bottomLine);
            wallList.Add(leftLine);
            wallList.Add(rightLine);
        }

        public void Draw()
        {
            foreach (var wall in wallList)
            {
                wall.Drow(); // Рисует каждую линию
            }

            // Углы
            Console.SetCursorPosition(0, 0); Console.Write("╔");
            Console.SetCursorPosition(80, 0); Console.Write("╗");
            Console.SetCursorPosition(0, 25); Console.Write("╚");
            Console.SetCursorPosition(80, 25); Console.Write("╝");
        }

        internal bool IsHit(Figure figure)
        {
            foreach (var wall in wallList)
            {
                if (wall.IsHit(figure))
                {
                    return true;
                }
            }
            return false;
        }
    }
}

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
            HorizontalLine topLine = new HorizontalLine(0, mapWidth, 2, '═');
            HorizontalLine bottomLine = new HorizontalLine(0, mapWidth, mapHeight, '═');

            // Вертикальная линия слева и справа
            VerticalLine leftLine = new VerticalLine(2, mapHeight, 0, '║');
            VerticalLine rightLine = new VerticalLine(2, mapHeight, mapWidth, '║');

            wallList.Add(topLine);
            wallList.Add(bottomLine);
            wallList.Add(leftLine);
            wallList.Add(rightLine);
        }

        public void Draw()
        {
            foreach (var wall in wallList)
            {
                wall.Draw(); // Рисует каждую линию
            }

            // Углы
            Console.SetCursorPosition(0, 2); Console.Write("╔");
            Console.SetCursorPosition(80, 2); Console.Write("╗");
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
        public List<Point> GetAllPoints()
        {
            return wallList.SelectMany(wall => wall.GetPoints()).ToList();
        }
        public void AddRandomWalls(int count)
        {
            Random rand = new Random();
            Console.ForegroundColor = ConsoleColor.Cyan;
            for (int i = 0; i < count; i++)
            {
                bool isHorizontal = rand.Next(2) == 0;

                if (isHorizontal)
                {
                    int x = rand.Next(2, 76); // максимум 76, чтобы x+3 = 79
                    int y = rand.Next(3, 22); // 3–21, не задеваем верх/низ
                    HorizontalLine line = new HorizontalLine(x, x + 4, y, '═');
                    wallList.Add(line);
                    line.Draw();
                }
                else
                {
                    int x = rand.Next(2, 78); // почти до правой стенки
                    int y = rand.Next(3, 19); // максимум 19, чтобы y+3 = 22
                    VerticalLine line = new VerticalLine(y, y + 4, x, '║');
                    wallList.Add(line);
                    line.Draw();
                }
            }
        }
    }
}

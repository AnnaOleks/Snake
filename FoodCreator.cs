using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class FoodCreator
    {
        int mapWidth;
        int mapHeight;
        char sym;

        Random random = new Random();

        public FoodCreator(int mapWidth, int mapHeight, char sym)
        {
            this.mapWidth = mapWidth;
            this.mapHeight = mapHeight;
            this.sym = sym;
        }

        // Создание еды с учётом запрещённых точек (стены, змейка)
        public Point CreateFood(List<Point> forbiddenPoints)
        {
            Point food;
            int attempts = 0; // Защита от бесконечного цикла
            do
            {
                int x = random.Next(2, mapWidth - 2);
                int y = random.Next(3, mapHeight - 2);
                food = new Point(x, y, sym);
                attempts++;

                if (attempts > 100) // Если не нашли подходящее место — возвращаем как есть
                {
                    break;
                }

            } while (forbiddenPoints.Any(p => p.IsHit(food)));

            return food;
        }

        public static void DrawFood(Point food)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(food.x, food.y);
            Console.Write(food.sym);
            Console.ResetColor();
        }
    }
}

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

        public Point CreateFood(List<Point> forbiddenPoints)
        {
            Point food;
            do
            {
                int x = random.Next(2, mapWidth - 2);
                int y = random.Next(3, mapHeight - 2);
                food = new Point(x, y, sym);
            } while (forbiddenPoints.Any(p => p.IsHit(food)));

            return food;
        }

        public static void DrawFood(Point food)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(food.x, food.y);
            Console.Write(food.sym);
            Console.ResetColor();
        }
    }
}

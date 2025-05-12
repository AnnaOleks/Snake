using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(85, 30);
            Console.CursorVisible = false;

            MenuManager menu = new MenuManager();
            ScoreManager scoreManager = new ScoreManager();

            while (true)
            {
                int choice = menu.ShowMainMenu();

                if (choice == 1) // Играть
                {
                    int level = menu.ShowLevelMenu();
                    int speed = level switch
                    {
                        1 => 150, // Легкий
                        2 => 100, // Средний
                        3 => 60   // Сложный
                    };

                    StartGame(speed, scoreManager); // Запуск игры
                }
                else if (choice == 2) // Показать рекорды
                {
                    scoreManager.ShowTopScores(); // Выведет ТОП
                    Console.WriteLine("\nНажмите любую клавишу...");
                    Console.ReadKey();
                }
                else if (choice == 3) // Выйти
                {
                    Console.WriteLine("Выход...");
                    break;
                }
            }
        }

        static void StartGame(int speed, ScoreManager scoreManager)
        {
            scoreManager.Reset(); // обнуляем счёт перед началом
            Console.Clear();

            Walls walls = new Walls(80, 25);
            walls.Draw();

            Point p = new Point(4, 5, '*');
            Snake snake = new Snake(p, 4, Direction.RIGHT);
            snake.Drow();

            FoodCreator foodCreator = new FoodCreator(78, 24, '$');
            Point food = foodCreator.CreateFood();
            food.Draw();

            while (true)
            {
                if (walls.IsHit(snake) || snake.IsHitTail())
                    break;

                if (snake.Eat(food))
                {
                    scoreManager.AddPoint(); // +1 очко
                    food = foodCreator.CreateFood();
                    food.Draw();
                }
                else
                {
                    snake.Move();
                }

                Thread.Sleep(speed);

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    snake.HandleKey(key.Key);
                }
            }

            string playerName = "";
            while (playerName.Length < 3)
            {
                Console.Write("Введите имя (минимум 3 символа): ");
                playerName = Console.ReadLine();
            }

            scoreManager.SaveScore(playerName);
            scoreManager.ShowTopScores();

            Console.WriteLine("\nНажмите любую клавишу...");
            Console.ReadKey();
        }
    }
}
     
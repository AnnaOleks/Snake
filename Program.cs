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
        public static void Main(string[] args)
        {
            Console.SetWindowSize(85, 30);
            Console.CursorVisible = false;

            Walls walls = new Walls(80, 25);    // Размер по умолчанию
            walls.Draw();                                       // Отрисовать рамку

            TitleScreen title = new TitleScreen(80,25);          // Новый экран
            ScoreManager scoreManager = new ScoreManager();


            while (true)
            {
                int choice = title.Show();

                if (choice == 1) // Играть
                {
                    MenuManager menu = new MenuManager();
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
            scoreManager.Reset();
            Console.Clear();

            // Верхняя панель
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╔══════════════════════════════════════════════════╗");
            Console.Write("║ ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(" ЗМЕЙКА ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(" | Очки: 0 ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("                           ║");
            Console.WriteLine("╚══════════════════════════════════════════════════╝");
            Console.ResetColor();

            // Отрисовка игровых границ
            Walls walls = new Walls(80, 25);
            walls.Draw();

            Point p = new Point(4, 5, '*');
            Snake snake = new Snake(p, 4, Direction.RIGHT);
            snake.Drow();

            FoodCreator foodCreator = new FoodCreator(77, 24, '$');
            Point food = foodCreator.CreateFood();
            FoodCreator.DrawFood(food); // с цветом

            while (true)
            {
                if (walls.IsHit(snake) || snake.IsHitTail())
                    break;

                if (snake.Eat(food))
                {
                    scoreManager.AddPoint();
                    ScoreManager.UpdateScorePanel(scoreManager.Score);
                    food = foodCreator.CreateFood();
                    FoodCreator.DrawFood(food);
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

            // После проигрыша
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
     
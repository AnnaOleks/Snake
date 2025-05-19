using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    internal class GameEngine
    {
        private readonly int width;
        private readonly int height;
        private readonly int speed;
        private readonly Player player;
        private readonly ScoreManager scoreManager;

        private Snake snake;
        private Walls walls;
        private FoodCreator foodCreator;
        private Point food;

        public GameEngine(int speed, Player player)
        {
            this.width = 80;
            this.height = 25;
            this.speed = speed;
            this.player = player;
            this.scoreManager = new ScoreManager();
        }

        public void Start()
        {
            Console.Clear();
            scoreManager.Reset();

            Utility.DrawTopPanel(scoreManager.Score, player.Name);
            walls = new Walls(width, height);
            walls.Draw();

            Point start = new Point(4, 5, '■');
            snake = new Snake(start, 4, Direction.RIGHT);
            snake.Draw();

            foodCreator = new FoodCreator(width, height, '$');
            var forbiddenPoints = walls.GetAllPoints().Concat(snake.GetPoints()).ToList();
            food = foodCreator.CreateFood(forbiddenPoints);

            GameLoop();
        }

        private void GameLoop()
        {
            while (true)
            {
                if (walls.IsHit(snake) || snake.IsHitTail())
                    break;

                if (snake.Eat(food))
                {
                    scoreManager.AddPoint();
                    Utility.DrawTopPanel(scoreManager.Score, player.Name);

                    var forbiddenPoints = walls.GetAllPoints().Concat(snake.GetPoints()).ToList();
                    food = foodCreator.CreateFood(forbiddenPoints);
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

            EndGame();
        }

        private void EndGame()
        {
            scoreManager.SaveScore(player.Name);
            GameOver.ShowGameOverPanel(scoreManager.Score, player.Name);
            scoreManager.ShowTopScores();

            Console.WriteLine("\nVajuta klahvi...");
            Console.ReadKey();
        }
    }
}


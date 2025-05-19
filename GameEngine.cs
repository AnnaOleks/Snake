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

        private readonly DifficultyManager difficulty;
        private int currentSpeed;
        private int lastMilestone = 0; // отслеживает предыдущую отметку по очкам

        public GameEngine(Player player, DifficultyManager difficulty)
        {
            this.width = 80;
            this.height = 25;
            this.difficulty = difficulty;
            this.player = player;
            this.scoreManager = new ScoreManager();
            this.currentSpeed = difficulty.GetInitialSpeed();
        }

        public void Start()
        {
            Console.Clear();
            scoreManager.Reset();

            Utility.DrawTopPanel(scoreManager.Score, player.Name);
            walls = new Walls(width, height);
            if (difficulty.ShouldAddRandomWall(0)) // не добавит, если уровень < 3
            {
                walls.AddRandomWalls(1);
            }
            walls.Draw();

            Point start = new Point(4, 5, '■');
            snake = new Snake(start, 4, Direction.RIGHT);
            snake.Draw();

            foodCreator = new FoodCreator(width, height, '$');
            var forbiddenPoints = walls.GetAllPoints().Concat(snake.GetPoints()).ToList();
            food = foodCreator.CreateFood(forbiddenPoints);
            FoodCreator.DrawFood(food); // Показываем еду на экране

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
                // Увеличиваем скорость, если нужно
                currentSpeed = difficulty.AdjustSpeed(scoreManager.Score);

                // Добавляем рандомную стену, если нужно
                if (difficulty.ShouldAddRandomWall(scoreManager.Score) && scoreManager.Score > lastMilestone)
                {
                    walls.AddRandomWalls(1);
                    lastMilestone = scoreManager.Score;

                    // Пересоздаём еду с учётом новой стены
                    var forbiddenPoints = walls.GetAllPoints().Concat(snake.GetPoints()).ToList();
                    food = foodCreator.CreateFood(forbiddenPoints);
                    FoodCreator.DrawFood(food);
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


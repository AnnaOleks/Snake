using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    internal class DifficultyManager
    {
        public int Level { get; }
        private int initialSpeed;

        public DifficultyManager(int level)
        {
            Level = level;
            initialSpeed = level switch
            {
                1 => 150,
                2 => 100,
                3 => 100,
                _ => 150
            };
        }

        public int GetInitialSpeed() => initialSpeed;

        public int AdjustSpeed(int score, int currentSpeed)
        {
            if (Level >= 2 && score > 0 && score % 5 == 0)
            {
                int newSpeed = currentSpeed - 10;
                return Math.Max(30, newSpeed); // ограничиваем минимальной скоростью
            }

            return currentSpeed;
        }

        public bool ShouldAddRandomWall(int score)
        {
            return Level == 3 && score > 0 && score % 5 == 0;
        }
    }
}


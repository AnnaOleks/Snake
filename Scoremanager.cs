using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class ScoreManager
    {
        private string filePath = "Nimed.txt"; // Путь к файлу

        public int Score { get; private set; } = 0;

        // Увеличить счёт
        public void AddPoint()
        {
            Score++;
        }

        // Сохраняем имя и очки в файл
        public void SaveScore(string playerName)
        {
            try
            {
                // Формат: имя;очки
                string record = $"{playerName};{Score}";
                File.AppendAllText(filePath, record + Environment.NewLine);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка при сохранении очков: " + ex.Message);
            }
        }

        // Показать ТОП N игроков
        public void ShowTopScores(int topN = 10)
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("Рекорды пока не сохранены.");
                return;
            }

            var records = File.ReadAllLines(filePath);
            var scoreList = new List<(string Name, int Points)>();

            foreach (var line in records)
            {
                var parts = line.Split(';');
                if (parts.Length == 2 && int.TryParse(parts[1], out int points))
                {
                    scoreList.Add((parts[0], points));
                }
            }

            var sorted = scoreList.OrderByDescending(p => p.Points).Take(topN);

            Console.WriteLine("\n--- ТОП ИГРОКОВ ---");
            foreach (var entry in sorted)
            {
                Console.WriteLine($"{entry.Name}: {entry.Points} очков");
            }
        }

        // Обнуление счёта
        public void Reset()
        {
            Score = 0;
        }

        public static void UpdateScorePanel(int score)
        {
            Console.SetCursorPosition(22, 1); // позиция "Очки: ..."
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"Очки: {score}    "); // подчистка
            Console.ResetColor();
        }
    }
}